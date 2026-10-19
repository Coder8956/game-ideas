using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker.Samples
{
    /// <summary>
    /// Quick and dirty script to update built-in materials to URP and HDRP materials.
    /// Used on samples made with the built-in renderer.
    /// </summary>
    /// <remarks>
    /// Do not use this in production code!
    /// In the real world you would update the materials once and tweak them to the new render pipeline.
    /// This utility script lets us ship samples made with built-in that are not broken in URP and HDRP.
    /// </remarks>
    [ExecuteAlways]
    [Obsolete("Use AutoFixSceneMaterials instead. This script will be removed in a future version.")]
    [Icon(Strings.EditorIconsPath + "PlayMakerUtilityIcon.png")]
    public class UpdateBuiltInMaterial : MonoBehaviour
    {
        [Tooltip("Leave empty to use the default URP material")]
        public Material UrpMaterial;
        
        [Tooltip("Leave empty to use the default HDRP material")]
        public Material HdrpMaterial;
        
        [Tooltip("Update materials on children also")]
        public bool UpdateChildren = true;

#if UNITY_EDITOR
        private bool _didUpdate;
#endif
        
        private void Awake()
        {
            // Builtin render pipeline?
            if (!GraphicsSettings.currentRenderPipeline) return;
            
            // Don't update while playing - it breaks instance materials.
            if (Application.isPlaying) return;
            
            var renderPipeline = GraphicsSettings.currentRenderPipeline.ToString();
            if (renderPipeline.Contains("UniversalRenderPipeline"))
            {
                UpdateToUrpMaterial();
            }
            else if (renderPipeline.Contains("HighDefinitionRenderPipeline"))
            {
                UpdateToHdrpMaterial();
            }
            else
            {
                Debug.LogWarning($"Unsupported render pipeline: {renderPipeline}");
            }
            
#if UNITY_EDITOR

            if (!_didUpdate) return;
            
            // Use delayCall so this is only called once
            // after all materials are updated.
            EditorApplication.delayCall -= GenerateLighting;
            EditorApplication.delayCall += GenerateLighting;
#endif
        }

#if UNITY_EDITOR
        private static void GenerateLighting()
        {
            if (Application.isPlaying) return;
            Lightmapping.BakeAsync();
            Debug.Log("Updated built-in materials for scriptable render pipelines. Generating lighting...");
        }
#endif
        
        private void UpdateToUrpMaterial()
        {
            if (UpdateChildren)
            {
                var renderers = GetComponentsInChildren<Renderer>();
                foreach (var targetRenderer in renderers)
                {
                    UpdateToUrpMaterial(targetRenderer);
                }
            }
            else
            {
                UpdateToUrpMaterial(GetComponent<Renderer>());
            }
        }
        
        private bool NeedsUpdate(Renderer targetRenderer)
        {
            var material = targetRenderer.sharedMaterial;
            return material && material != UrpMaterial && material != HdrpMaterial 
                   && material != GraphicsSettings.currentRenderPipeline.defaultMaterial;
        }
        
        private void UpdateToUrpMaterial(Renderer targetRenderer)
        {
            if (!NeedsUpdate(targetRenderer)) return;
            
            targetRenderer.SetMaterials(!UrpMaterial
                ? new List<Material> { GraphicsSettings.currentRenderPipeline.defaultMaterial }
                : new List<Material> { UrpMaterial });
            
#if UNITY_EDITOR
            _didUpdate = true;
#endif
        }
        
        private void UpdateToHdrpMaterial()
        {
            if (UpdateChildren)
            {
                var renderers = GetComponentsInChildren<Renderer>();
                foreach (var targetRenderer in renderers)
                {
                    UpdateToHdrpMaterial(targetRenderer);
                }
            }
            else
            {
                UpdateToHdrpMaterial(GetComponent<Renderer>());
            }
        }
        
        private void UpdateToHdrpMaterial(Renderer targetRenderer)
        {
            if (!NeedsUpdate(targetRenderer)) return;
            
            targetRenderer.SetMaterials(!UrpMaterial
                ? new List<Material> { GraphicsSettings.currentRenderPipeline.defaultMaterial }
                : new List<Material> { HdrpMaterial });
            
#if UNITY_EDITOR
            _didUpdate = true;
#endif
        }
    }
}
