using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif

namespace HutongGames.PlayMaker.Samples
{

// Attempts to fix sample scenes so they work with any render pipeline.
//
// We use 2 main approaches:
// 1. Models with embedded materials.
// 2. Alternate materials for each render pipeline.
//
// 1. Models with embedded materials.
// Any render pipeline can use materials embedded in the fbx. 
// However, models saved in a scene will have material overrides when opened in a different pipeline.
// This breaks models that would otherwise "just work." To fix this, we simply revert these overrides.
// This allows the active render pipeline to use the original model.
//
// 2. Alternate materials for each render pipeline.
// This approach supplies alternate materials for each render pipeline.
// Then we swap any materials in the scene with the material for the active pipeline.

    [ExecuteAlways]
    [Icon(Strings.EditorIconsPath + "PlayMakerUtilityIcon.png")]
    public sealed class AutoFixSceneMaterials : MonoBehaviour
    {
        [Serializable]
        public class AlternateMaterials
        {
            public Material BuiltInMaterial;
            public Material UrpMaterial;
            public Material HdrpMaterial;
        }

#if UNITY_EDITOR

        [Tooltip("Run automatically on scene load (Editor only).")]
        public bool autoRunOnLoad = true;

        [Tooltip("If enabled, scan ALL loaded scenes; otherwise only this component's scene.")]
        public bool includeAllLoadedScenes = false;

        [Tooltip("A list of alternate materials for each render pipeline.")]
        public AlternateMaterials[] materials;

        [Tooltip("Optional list of prefabs to check also.")]
        public GameObject[] prefabs;

        [Tooltip("Process prefab assets in the prefab list when this component auto-runs in the editor.")]
        public bool autoProcessPrefabs;

        [Tooltip("Ask for confirmation before modifying prefab assets from the prefab list.")]
        public bool confirmPrefabUpdates = true;

        private bool _didUpdate;
        private Dictionary<Material, Material> _urpMaterialLookup;
        private Dictionary<Material, Material> _hdrpMaterialLookup;

        private void OnEnable()
        {
            if (!autoRunOnLoad) return;

            // Don't run inside Prefab Isolation
            if (PrefabStageUtility.GetCurrentPrefabStage() != null) return;

            // Defer one tick so scenes are fully loaded
            EditorApplication.delayCall -= RunOnceOnLoad;
            EditorApplication.delayCall += RunOnceOnLoad;

            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.delayCall -= RunOnceOnLoad;
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        private void OnValidate()
        {
            ResetMaterialLookups();
        }

        [ContextMenu("Run Now")]
        private void RunOnce()
        {
            UpdateScenes();
        }

        [ContextMenu("Update Prefab Assets")]
        private void RunPrefabUpdate()
        {
            UpdatePrefabAssets(confirmPrefabUpdates);
        }

        [ContextMenu("Reset Prefab Auto Process Prompt")]
        private void ResetPrefabAutoProcessPrompt()
        {
            ClearAutoProcessPrefabsAttempt();
        }

        public bool UpdateScenes()
        {
            if (!this) return false;

            _didUpdate = false;
            ResetMaterialLookups();

            var changed = false;

            if (includeAllLoadedScenes)
            {
                for (var i = 0; i < SceneManager.sceneCount; i++)
                {
                    var scene = SceneManager.GetSceneAt(i);
                    if (!scene.IsValid() || !scene.isLoaded) continue;
                    changed |= FixScene(scene);
                }
            }
            else
            {
                var scene = gameObject.scene;
                if (scene.IsValid() && scene.isLoaded)
                    changed |= FixScene(scene);
            }

            if (changed)
            {
                Debug.Log("Updated materials for scriptable render pipelines.");

                // Mark modified scenes dirty so the user can save the fixes
                MarkScenesDirty();

                // Generate lighting if materials were updated
                if (_didUpdate)
                {
                    EditorApplication.delayCall -= GenerateLighting;
                    EditorApplication.delayCall += GenerateLighting;
                }
            }

            return changed;
        }

        public int UpdatePrefabAssets(bool confirmUpdate)
        {
            if (!this || prefabs == null || prefabs.Length == 0) return 0;

            if (Application.isPlaying) return 0;

            // Built-in render pipeline? No need to update.
            if (!GraphicsSettings.currentRenderPipeline) return 0;

            var prefabPaths = GetPrefabAssetPaths();
            if (prefabPaths.Count == 0) return 0;

            if (confirmUpdate)
            {
                var proceed = EditorUtility.DisplayDialog(
                    "Update Prefab Materials",
                    $"This will update {prefabPaths.Count} prefab asset(s) in the prefab list for the active render pipeline.\n\nAre you sure?",
                    "Update Prefabs",
                    "Cancel");

                if (!proceed) return -1;
            }

            _didUpdate = false;
            ResetMaterialLookups();

            var changedCount = 0;

            foreach (var prefabPath in prefabPaths)
            {
                var prefabRoot = PrefabUtility.LoadPrefabContents(prefabPath);

                try
                {
                    if (!FixHierarchy(prefabRoot)) continue;

                    PrefabUtility.SaveAsPrefabAsset(prefabRoot, prefabPath);
                    changedCount++;
                }
                finally
                {
                    PrefabUtility.UnloadPrefabContents(prefabRoot);
                }
            }

            if (changedCount > 0)
            {
                AssetDatabase.SaveAssets();
                Debug.Log($"Updated materials on {changedCount} prefab asset(s) for scriptable render pipelines.");
            }

            return changedCount;
        }

        private void RunOnceOnLoad()
        {
            UpdateScenes();

            TryAutoProcessPrefabsOnLoad();
        }

        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingEditMode) return;
            if (!autoRunOnLoad) return;
            if (PrefabStageUtility.GetCurrentPrefabStage() != null) return;

            EditorApplication.delayCall -= RunOnceOnLoad;

            UpdateScenes();
            TryAutoProcessPrefabsOnPlay();
        }

        private void TryAutoProcessPrefabsOnLoad()
        {
            if (!autoProcessPrefabs || HasConsumedAutoProcessPrefabsAttempt()) return;

            TryAutoProcessPrefabs(consumeAttempt: true);
        }

        private void TryAutoProcessPrefabsOnPlay()
        {
            if (!autoProcessPrefabs) return;

            TryAutoProcessPrefabs(consumeAttempt: false);
        }

        private void TryAutoProcessPrefabs(bool consumeAttempt)
        {
            if (prefabs == null || prefabs.Length == 0)
            {
                //Debug.Log("Prefab auto-processing skipped: the prefab list is empty.");
                return;
            }

            var prefabPaths = GetPrefabAssetPaths();
            if (prefabPaths.Count == 0)
            {
                //Debug.Log("Prefab auto-processing skipped: the prefab list does not contain any prefab asset references. Use prefab assets, not scene instances.");
                return;
            }

            if (consumeAttempt)
            {
                ConsumeAutoProcessPrefabsAttempt();
            }

            var changedCount = UpdatePrefabAssets(confirmPrefabUpdates);
            if (changedCount < 0)
            {
                Debug.Log("Prefab auto-processing was canceled. Use the Update Prefabs button to run it manually later.");
            }
        }

        private static void GenerateLighting()
        {
            if (Application.isPlaying) return;
            Lightmapping.BakeAsync();
            Debug.Log("Generating lighting...");
        }

        private void MarkScenesDirty()
        {
            if (includeAllLoadedScenes)
            {
                for (var i = 0; i < SceneManager.sceneCount; i++)
                {
                    var s = SceneManager.GetSceneAt(i);
                    if (s.IsValid() && s.isLoaded) EditorSceneManager.MarkSceneDirty(s);
                }
            }
            else
            {
                EditorSceneManager.MarkSceneDirty(gameObject.scene);
            }
        }

        private bool FixScene(Scene scene)
        {
            var any = false;
            var roots = scene.GetRootGameObjects();
            foreach (var go in roots)
            {
                any |= FixHierarchy(go);
            }

            return any;
        }

        private bool FixHierarchy(GameObject root)
        {
            var any = false;
            var renderers = root.GetComponentsInChildren<Renderer>(true);
            foreach (var r in renderers)
            {
                any |= UpdateRendererMaterials(r);
            }

            return any;
        }

        private bool UpdateRendererMaterials(Renderer targetRenderer)
        {
            // Don't update while playing - it breaks instance materials.
            if (Application.isPlaying) return false;

            // Built-in render pipeline? No need to update
            if (!GraphicsSettings.currentRenderPipeline) return false;

            var renderPipeline = GraphicsSettings.currentRenderPipeline.ToString();
            var updated = false;

            if (renderPipeline.Contains("UniversalRenderPipeline"))
            {
                updated = UpdateToUrpMaterial(targetRenderer);
            }
            else if (renderPipeline.Contains("HighDefinitionRenderPipeline"))
            {
                updated = UpdateToHdrpMaterial(targetRenderer);
            }

            if (updated)
            {
                _didUpdate = true;
            }

            return updated;
        }

        private bool UpdateToUrpMaterial(Renderer targetRenderer)
        {
            var currentMaterials = new List<Material>();
            targetRenderer.GetSharedMaterials(currentMaterials);
            var newMaterials = new List<Material>();
            var wasUpdated = false;

            foreach (var currentMaterial in currentMaterials)
            {
                var replacementMaterial = GetReplacementMaterial(currentMaterial, isUrp: true);
                if (replacementMaterial != null && replacementMaterial != currentMaterial)
                {
                    newMaterials.Add(replacementMaterial);
                    wasUpdated = true;
                }
                else
                {
                    newMaterials.Add(currentMaterial);
                }
            }

            if (wasUpdated)
            {
                targetRenderer.SetSharedMaterials(newMaterials);
            }

            return wasUpdated;
        }

        private bool UpdateToHdrpMaterial(Renderer targetRenderer)
        {
            var currentMaterials = new List<Material>();
            targetRenderer.GetSharedMaterials(currentMaterials);
            var newMaterials = new List<Material>();
            var wasUpdated = false;

            foreach (var currentMaterial in currentMaterials)
            {
                var replacementMaterial = GetReplacementMaterial(currentMaterial, isUrp: false);
                if (replacementMaterial != null && replacementMaterial != currentMaterial)
                {
                    newMaterials.Add(replacementMaterial);
                    wasUpdated = true;
                }
                else
                {
                    newMaterials.Add(currentMaterial);
                }
            }

            if (wasUpdated)
            {
                targetRenderer.SetSharedMaterials(newMaterials);
            }

            return wasUpdated;
        }

        private Material GetReplacementMaterial(Material currentMaterial, bool isUrp)
        {
            if (currentMaterial == null || materials == null) return null;

            var lookup = isUrp ? GetUrpMaterialLookup() : GetHdrpMaterialLookup();
            return lookup.TryGetValue(currentMaterial, out var replacementMaterial)
                ? replacementMaterial
                : null;
        }

        private Dictionary<Material, Material> GetUrpMaterialLookup()
        {
            if (_urpMaterialLookup != null) return _urpMaterialLookup;

            _urpMaterialLookup = BuildMaterialLookup(isUrp: true);
            return _urpMaterialLookup;
        }

        private Dictionary<Material, Material> GetHdrpMaterialLookup()
        {
            if (_hdrpMaterialLookup != null) return _hdrpMaterialLookup;

            _hdrpMaterialLookup = BuildMaterialLookup(isUrp: false);
            return _hdrpMaterialLookup;
        }

        private Dictionary<Material, Material> BuildMaterialLookup(bool isUrp)
        {
            var lookup = new Dictionary<Material, Material>();

            foreach (var alternateMaterials in materials)
            {
                if (alternateMaterials == null || alternateMaterials.BuiltInMaterial == null)
                {
                    continue;
                }

                lookup[alternateMaterials.BuiltInMaterial] = isUrp
                    ? alternateMaterials.UrpMaterial
                    : alternateMaterials.HdrpMaterial;
            }

            return lookup;
        }

        private void ResetMaterialLookups()
        {
            _urpMaterialLookup = null;
            _hdrpMaterialLookup = null;
        }

        private List<string> GetPrefabAssetPaths()
        {
            var prefabPaths = new List<string>();
            var uniquePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var prefab in prefabs)
            {
                if (!prefab) continue;

                var prefabPath = AssetDatabase.GetAssetPath(prefab);
                if (string.IsNullOrEmpty(prefabPath)) continue;
                if (!PrefabUtility.IsPartOfPrefabAsset(prefab)) continue;
                if (!uniquePaths.Add(prefabPath)) continue;

                prefabPaths.Add(prefabPath);
            }

            return prefabPaths;
        }

        public void ClearAutoProcessPrefabsAttempt()
        {
            var key = GetAutoProcessPrefabsAttemptKey();
            if (string.IsNullOrEmpty(key)) return;

            EditorPrefs.DeleteKey(key);
        }

        private bool HasConsumedAutoProcessPrefabsAttempt()
        {
            var key = GetAutoProcessPrefabsAttemptKey();
            return !string.IsNullOrEmpty(key) && EditorPrefs.GetBool(key, false);
        }

        private void ConsumeAutoProcessPrefabsAttempt()
        {
            var key = GetAutoProcessPrefabsAttemptKey();
            if (string.IsNullOrEmpty(key)) return;

            EditorPrefs.SetBool(key, true);
        }

        private string GetAutoProcessPrefabsAttemptKey()
        {
            var globalObjectId = GlobalObjectId.GetGlobalObjectIdSlow(this).ToString();
            var scenePath = gameObject.scene.path ?? string.Empty;
            return $"PlayMaker.AutoFixSceneMaterials.AutoProcessPrefabs.{scenePath}.{globalObjectId}";
        }

#else
        // Editor-only logic; no-op in Player.
        void OnEnable() { }

#endif
    }
}
