using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Editor
{
    [CustomEditor(typeof(Interactor))]
    [CanEditMultipleObjects]
    public sealed class InteractorEditor : UnityEditor.Editor
    {
        private SerializedProperty _referenceTransformProp;
        private SerializedProperty _interactableLayersProp;
        private SerializedProperty _blockingLayersProp;
        private SerializedProperty _hitTriggersProp;
        private SerializedProperty _requiredTagProp;
        private SerializedProperty _searchRadiusProp;

        private void OnEnable()
        {
            _referenceTransformProp = serializedObject.FindProperty("_referenceTransform");
            _interactableLayersProp = serializedObject.FindProperty("_interactableLayers");
            _blockingLayersProp = serializedObject.FindProperty("_blockingLayers");
            _hitTriggersProp = serializedObject.FindProperty("_hitTriggers");
            _requiredTagProp = serializedObject.FindProperty("_requiredTag");
            _searchRadiusProp = serializedObject.FindProperty("_searchRadius");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_referenceTransformProp, new GUIContent("Reference Transform"));
            EditorGUILayout.PropertyField(_interactableLayersProp, new GUIContent("Interactable Layers"));
            EditorGUILayout.PropertyField(_blockingLayersProp, new GUIContent("Blocking Layers"));
            EditorGUILayout.PropertyField(_hitTriggersProp, new GUIContent("Hit Triggers"));
            EditorGUILayout.PropertyField(_requiredTagProp, new GUIContent("Required Tag"));
            EditorGUILayout.PropertyField(_searchRadiusProp, new GUIContent("Search Radius"));

            serializedObject.ApplyModifiedProperties();

            if (serializedObject.isEditingMultipleObjects)
            {
                return;
            }

            if (target is not Interactor controller)
            {
                return;
            }

            DrawRuntimeDebug(controller);
        }

        public override bool RequiresConstantRepaint()
        {
            return Application.isPlaying;
        }

        private static void DrawRuntimeDebug(Interactor controller)
        {
            DrawHeader("Runtime Debug");

            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox("Runtime debug information is available in Play Mode.", MessageType.Info);
                return;
            }

            var selected = string.IsNullOrEmpty(controller.DebugBestTargetName)
                ? "none"
                : $"{controller.DebugBestTargetName} ({controller.DebugBestType})  distance={controller.DebugBestDistance:0.##}";

            var resolvedReferenceTransform = controller.DebugResolvedReferenceTransform;
            var referenceSummary = resolvedReferenceTransform != null
                ? $"{resolvedReferenceTransform.name}"
                : "none";
            var lockedInteractable = controller.DebugLockedInteractable;
            var lockedSummary = lockedInteractable != null
                ? $"{lockedInteractable.gameObject.name} ({lockedInteractable.Interaction})"
                : "none";

            EditorGUILayout.LabelField("Scan",
                                       $"Hits={controller.DebugHitCount}  Interactables={controller.DebugResolvedInteractables}  Valid={controller.DebugValidCandidates}" +
                                       (controller.DebugRaycastRequired ? $"  RaycastHit={controller.DebugRaycastHit}" : string.Empty));
            EditorGUILayout.LabelField("State",
                                       $"LockActiveInteraction={controller.LockActiveInteraction}  CanInteract={controller.CanInteract}  DidActivateThisUpdate={controller.DidActivateThisUpdate}");
            EditorGUILayout.LabelField("Activation",
                                       controller.DebugHasActivationAttempt
                                           ? $"Pressed={controller.DebugLastInteractPressed}  InputId={controller.DebugLastInputActivationId}  State={controller.DebugActivationState}"
                                           : controller.DebugActivationState);
            EditorGUILayout.LabelField("Selection",
                                       $"Reference={referenceSummary}  Current={lockedSummary}" +
                                       (controller.DebugUsingLockedInteractable ? "  Source=LockedActive" : "  Source=Passive"));
            EditorGUILayout.LabelField("Rejected", FormatRejectedSummary(controller));
            EditorGUILayout.LabelField("Selected", selected);

            if (controller.DebugCandidates.Count == 0)
            {
                if (!controller.DebugUpdatedThisFrame)
                {
                    EditorGUILayout.HelpBox("This interactor was not updated this frame. If interactions are still working, another Interactor instance is likely driving them.", MessageType.Warning);
                }
                else if (controller.DebugUsingLockedInteractable)
                {
                    EditorGUILayout.HelpBox("No passive candidates were recorded this frame. The current selection is being kept by Lock Active Interaction.", MessageType.Info);
                }

                EditorGUILayout.HelpBox("No passive candidates evaluated this frame.", MessageType.None);
                return;
            }

            EditorGUILayout.Space(4f);
            EditorGUILayout.LabelField("Candidates", EditorStyles.boldLabel);

            for (var i = 0; i < controller.DebugCandidates.Count; i++)
            {
                var candidate = controller.DebugCandidates[i];
                var interactable = candidate.Interactable;
                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.ObjectField(interactable, typeof(Interactable), true);
                        GUI.enabled = interactable != null;
                        if (GUILayout.Button("Select", GUILayout.Width(56f)) && interactable != null)
                        {
                            Selection.activeGameObject = interactable.gameObject;
                            EditorGUIUtility.PingObject(interactable.gameObject);
                        }

                        GUI.enabled = true;
                    }

                    EditorGUILayout.LabelField("Result", candidate.Result);
                    var axis = interactable != null ? interactable.MeasurementAxis.ToString() : "Unknown";
                    var distanceMode = interactable != null ? interactable.PositionDistanceMode.ToString() : "Unknown";
                    EditorGUILayout.LabelField("Distance",
                                               $"{candidate.Distance:0.##} [{axis}]  Raw3D: {candidate.RawDistance:0.##}  Limit: {(candidate.LocalMaxDistance > 0f ? candidate.LocalMaxDistance.ToString("0.##") : "off")}");
                    EditorGUILayout.LabelField("Mode", distanceMode);
                    if (interactable != null && interactable.RequireApproach)
                    {
                        EditorGUILayout.LabelField("Approach",
                                                   $"angle={candidate.ApproachAngle:0.##}/{candidate.MaxApproachAngle:0.##}");
                    }

                    if (interactable != null && interactable.RequireFacing)
                    {
                        EditorGUILayout.LabelField("Facing",
                                                   $"angle={candidate.FacingAngle:0.##}/{candidate.MaxFacingAngle:0.##}");
                    }
                }
            }
        }

        private static string FormatRejectedSummary(Interactor controller)
        {
            var parts = new System.Collections.Generic.List<string>(7);
            AddRejectedPart(parts, "Tag", controller.DebugRejectedByTag);
            AddRejectedPart(parts, "Interact", controller.DebugRejectedByUse);
            AddRejectedPart(parts, "Distance", controller.DebugRejectedByDistance);
            AddRejectedPart(parts, "InsideTrigger", controller.DebugRejectedByInsideTrigger);
            AddRejectedPart(parts, "Approach", controller.DebugRejectedByApproach);
            AddRejectedPart(parts, "Facing", controller.DebugRejectedByFacing);
            AddRejectedPart(parts, "Raycast", controller.DebugRejectedByRaycast);

            return parts.Count == 0 ? "none" : string.Join("  ", parts);
        }

        private static void AddRejectedPart(System.Collections.Generic.ICollection<string> parts, string label, int count)
        {
            if (count > 0)
            {
                parts.Add($"{label}={count}");
            }
        }

        private static void DrawHeader(string text)
        {
            EditorGUILayout.Space(6f);
            EditorGUILayout.LabelField(text, EditorStyles.boldLabel);
        }
    }
}
