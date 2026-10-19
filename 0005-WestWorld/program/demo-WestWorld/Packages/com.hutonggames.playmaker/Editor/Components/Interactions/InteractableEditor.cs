using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using HutongGames.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Editor
{
    [CustomEditor(typeof(Interactable))]
    [CanEditMultipleObjects]
    public sealed class InteractableEditor : UnityEditor.Editor
    {
        private const float GizmoLineThickness = 2f;
        private const string ActivationTooltip = "The interaction requires activation to trigger. " +
                                                 "Example: a button or ATM usually needs activation, " +
                                                 "while a ladder or climb volume may not. " +
                                                 "\n\nOptionally provide an ID to match a specific activator.";

        private const string ActivationIdTooltip = "An optional ID used to match activation to a specific input.";
        private static readonly Color DistanceColor = new(0.2f, 0.8f, 1f, 0.9f);
        private static readonly Color DistanceFillColor = new(0.2f, 0.8f, 1f, 0.08f);
        private static readonly Color CombinedConstraintFillColor = new(0.55f, 0.8f, 0.55f, 0.1f);
        private static readonly Color MinDistanceColor = new(1f, 0.55f, 0.2f, 0.95f);
        private static readonly Color BoxDistanceColor = new(0.95f, 0.45f, 0.2f, 0.95f);
        private static readonly Color BoxDistanceMutedColor = new(0.95f, 0.45f, 0.2f, 0.4f);
        private static readonly Color ApproachColor = new(1f, 0.75f, 0.2f, 0.95f);
        private static readonly Color ApproachFillColor = new(1f, 0.75f, 0.2f, 0.08f);
        private static readonly Color FacingColor = new(0.4f, 0.9f, 1f, 0.95f);
        private static readonly Color FacingFillColor = new(0.4f, 0.9f, 1f, 0.08f);
        private static readonly Color InvalidConstraintColor = new(1f, 0.3f, 0.3f, 0.95f);
        private static readonly Color AnchorColor = new(0.4f, 1f, 0.4f, 1f);
        private const float SingleAxisStripWidthScale = 0.18f;
        private const int ConeFillRadialSegments = 32;
        private const int ConeFillPolarSegments = 12;
        private const int PlanarFillArcSegments = 40;
        private const int BoxConeArcSegments = 40;
        private static Material _constraintFillMaterial;
        private static Mesh _constraintFillMesh;
        private static readonly List<Vector3> ConstraintFillVertices = new();
        private static readonly List<int> ConstraintFillTriangles = new();
        private static readonly Dictionary<int, Vector3> FacingPreviewOverrides = new();

        private SerializedObject _serializedObject;
        private SerializedProperty _interactionProp;
        private SerializedProperty _activationIdProp;
        private SerializedProperty _targetGameObjectProp;
        private SerializedProperty _isEnabledProp;
        private SerializedProperty _measurementAxisProp;
        private SerializedProperty _measurementSpaceProp;
        private SerializedProperty _distanceModeProp;
        private SerializedProperty _positionConstraintModeProp;
        private SerializedProperty _minInteractionDistanceProp;
        private SerializedProperty _maxInteractionDistanceProp;
        private SerializedProperty _maxPositionDeltaProp;
        private SerializedProperty _insideTriggerProp;
        private SerializedProperty _requireApproachProp;
        private SerializedProperty _maxApproachAngleProp;
        private SerializedProperty _requireFacingProp;
        private SerializedProperty _maxFacingAngleProp;
        private SerializedProperty _invertFacingProp;
        private SerializedProperty _authoredDirectionAxisProp;
        private SerializedProperty _requireRaycastHitProp;
        private SerializedProperty _isExplicitInteractionProp;
        private SerializedProperty _priorityProp;
        private SerializedProperty _dockingTransformProp;
        private SerializedProperty _dockingPolicyProp;
        private SerializedProperty _dockPositionProp;
        private SerializedProperty _dockPositionAxisProp;
        private SerializedProperty _dockRotationProp;
        private SerializedProperty _undockingTransformProp;
        
        private void OnEnable()
        {
            _serializedObject = new SerializedObject(targets);
            _interactionProp = _serializedObject.FindProperty("_interaction");
            _activationIdProp = _serializedObject.FindProperty("_activationId");
            _targetGameObjectProp = _serializedObject.FindProperty("_targetGameObject");
            _isEnabledProp = _serializedObject.FindProperty("_isEnabled");
            _measurementAxisProp = _serializedObject.FindProperty("_measurementAxis");
            _measurementSpaceProp = _serializedObject.FindProperty("_measurementSpace");
            _distanceModeProp = _serializedObject.FindProperty("_distanceMode");
            _positionConstraintModeProp = _serializedObject.FindProperty("_positionConstraintMode");
            _minInteractionDistanceProp = _serializedObject.FindProperty("_minInteractionDistance");
            _maxInteractionDistanceProp = _serializedObject.FindProperty("_maxInteractionDistance");
            _maxPositionDeltaProp = _serializedObject.FindProperty("_maxPositionDelta");
            _insideTriggerProp = _serializedObject.FindProperty("_insideTrigger");
            _requireApproachProp = _serializedObject.FindProperty("_requireApproach");
            _maxApproachAngleProp = _serializedObject.FindProperty("_maxApproachAngle");
            _requireFacingProp = _serializedObject.FindProperty("_requireFacing");
            _maxFacingAngleProp = _serializedObject.FindProperty("_maxFacingAngle");
            _invertFacingProp = _serializedObject.FindProperty("_invertFacing");
            _authoredDirectionAxisProp = _serializedObject.FindProperty("_authoredDirectionAxis");
            _requireRaycastHitProp = _serializedObject.FindProperty("_requireRaycastHit");
            _isExplicitInteractionProp = _serializedObject.FindProperty("_isExplicitInteraction");
            _priorityProp = _serializedObject.FindProperty("_priority");
            _dockingTransformProp = _serializedObject.FindProperty("_dockingTransform");
            _dockingPolicyProp = _serializedObject.FindProperty("_dockingPolicy");
            _dockPositionProp = _serializedObject.FindProperty("_dockPosition");
            _dockPositionAxisProp = _serializedObject.FindProperty("_dockPositionAxis");
            _dockRotationProp = _serializedObject.FindProperty("_dockRotation");
            _undockingTransformProp = _serializedObject.FindProperty("_undockingTransform");
        }

        public override void OnInspectorGUI()
        {
            _serializedObject.Update();

            DrawWarnings();

            DrawInteractionHeader();
            EditorGUILayout.PropertyField(_interactionProp, new GUIContent("Name"));
            EditorGUILayout.PropertyField(_targetGameObjectProp, new GUIContent("Target GameObject"));
            EditorGUILayout.PropertyField(_authoredDirectionAxisProp, new GUIContent("Interaction Direction"));
            DrawActivationRow();
            EditorGUILayout.PropertyField(_priorityProp);

            DrawHeader("Range");
            EditorGUILayout.PropertyField(_insideTriggerProp, new GUIContent("Inside Trigger"));
            EditorGUILayout.PropertyField(_distanceModeProp, new GUIContent("Distance From"));
            EditorGUILayout.PropertyField(_positionConstraintModeProp, new GUIContent("Distance Mode"));
            DrawPositionConstraintFields();

            DrawHeader("Approach");
            EditorGUILayout.PropertyField(_requireApproachProp, new GUIContent("Require Approach"));
            using (new EditorGUI.DisabledScope(!_requireApproachProp.boolValue && !_requireApproachProp.hasMultipleDifferentValues))
            {
                using (new EditorGUI.DisabledScope(IsSingleAxisMeasurementMode(_measurementAxisProp)))
                {
                    EditorGUILayout.PropertyField(_maxApproachAngleProp, new GUIContent("Max Approach Angle"));
                }
                EditorGUILayout.PropertyField(_invertFacingProp, new GUIContent("Invert Approach"));
            }

            DrawHeader("Facing");
            EditorGUILayout.PropertyField(_requireFacingProp, new GUIContent("Require Facing"));
            using (new EditorGUI.DisabledScope(!_requireFacingProp.boolValue && !_requireFacingProp.hasMultipleDifferentValues))
            {
                EditorGUILayout.PropertyField(_maxFacingAngleProp, new GUIContent("Facing Tolerance"));
            }
            EditorGUILayout.PropertyField(_requireRaycastHitProp, new GUIContent("Require Raycast Hit"));

            DrawHeader("Docking");
            EditorGUILayout.PropertyField(_dockingPolicyProp, new GUIContent("Interaction Alignment"));
            EditorGUILayout.PropertyField(_dockingTransformProp, new GUIContent("Docking Transform"));
            using (new EditorGUI.DisabledScope(_dockingPolicyProp.enumValueIndex == (int)Interactable.DockingPolicy.None &&
                                               !_dockingPolicyProp.hasMultipleDifferentValues))
            {
                EditorGUILayout.PropertyField(_dockPositionProp, new GUIContent("Dock Position"));
                using (new EditorGUI.DisabledScope(!_dockPositionProp.boolValue && !_dockPositionProp.hasMultipleDifferentValues))
                {
                    EditorGUILayout.PropertyField(_dockPositionAxisProp, new GUIContent("Position Axis"));
                }

                EditorGUILayout.PropertyField(_dockRotationProp, new GUIContent("Dock Rotation"));
            }
            EditorGUILayout.PropertyField(_undockingTransformProp, new GUIContent("Undocking Transform"));
            if (_serializedObject.ApplyModifiedProperties())
            {
                InteractableEditorEvents.RaiseChanged();
            }
        }

        private void DrawActivationRow()
        {
            var rowRect = EditorGUILayout.GetControlRect();
            var contentRect = EditorGUI.PrefixLabel(rowRect,
                EditorGUIUtility.TrTextContent("Needs Activation", ActivationTooltip));

            const float toggleWidth = 16f;
            const float toggleGap = 6f;
            const float labelGap = 2f;
            var idLabelWidth = Mathf.Ceil(EditorStyles.label.CalcSize(new GUIContent("ID")).x);

            var toggleRect = new Rect(contentRect.x, contentRect.y, toggleWidth, contentRect.height);
            var idLabelRect = new Rect(toggleRect.xMax + toggleGap, contentRect.y, idLabelWidth, contentRect.height);
            var idFieldRect = new Rect(idLabelRect.xMax + labelGap,
                contentRect.y,
                Mathf.Max(0f, contentRect.xMax - (idLabelRect.xMax + labelGap)),
                contentRect.height);

            EditorGUI.BeginProperty(rowRect, GUIContent.none, _isExplicitInteractionProp);
            EditorGUI.showMixedValue = _isExplicitInteractionProp.hasMultipleDifferentValues;
            EditorGUI.BeginChangeCheck();
            var needsActivation = EditorGUI.Toggle(toggleRect, GUIContent.none, _isExplicitInteractionProp.boolValue);
            if (EditorGUI.EndChangeCheck())
            {
                _isExplicitInteractionProp.boolValue = needsActivation;
            }
            EditorGUI.showMixedValue = false;

            using (new EditorGUI.DisabledScope(!_isExplicitInteractionProp.boolValue && !_isExplicitInteractionProp.hasMultipleDifferentValues))
            {
                EditorGUI.LabelField(idLabelRect, new GUIContent("ID", ActivationIdTooltip));
                EditorGUI.BeginProperty(idFieldRect, GUIContent.none, _activationIdProp);
                EditorGUI.showMixedValue = _activationIdProp.hasMultipleDifferentValues;
                EditorGUI.BeginChangeCheck();
                var activationId = EditorGUI.TextField(idFieldRect, GUIContent.none, _activationIdProp.stringValue);
                if (EditorGUI.EndChangeCheck())
                {
                    _activationIdProp.stringValue = activationId;
                }
                EditorGUI.showMixedValue = false;
                EditorGUI.EndProperty();
            }

            EditorGUI.EndProperty();
        }

        private void DrawWarnings()
        {
            var interactable = target as Interactable;
            var hasCollider = interactable != null && HasResolvableCollider(interactable);
            var showMissingColliderWarning = interactable != null && !hasCollider;
            var showColliderWarning = showMissingColliderWarning &&
                                      interactable.DistanceFrom == Interactable.DistanceFromMode.Collider;
            var showRaycastWarning = showMissingColliderWarning && interactable.RequireRaycastHit;
            var showInsideTriggerWarning = interactable != null &&
                                           interactable.InsideTrigger != null &&
                                           !interactable.InsideTrigger.isTrigger;
            var showUnsupportedInsideTriggerWarning = interactable != null &&
                                                     interactable.InsideTrigger != null &&
                                                     !PhysicsColliderQueries.IsSupportedOverlapCollider(interactable.InsideTrigger);

            if (showMissingColliderWarning)
            {
                EditorGUILayout.HelpBox(
                    "This Interactable will not be found by Update Interactables actions without at least one Collider on this object, its children, or an ancestor hierarchy that can resolve this point.",
                    MessageType.Warning);
            }

            if (showColliderWarning)
            {
                EditorGUILayout.HelpBox(
                    "Collider distance mode needs at least one Collider on this object, its children, or an ancestor hierarchy that can resolve this point.",
                    MessageType.Warning);
            }

            if (showRaycastWarning)
            {
                EditorGUILayout.HelpBox(
                    "Require Raycast Hit needs at least one Collider on this object, its children, or an ancestor hierarchy that can resolve this point.",
                    MessageType.Warning);
            }

            if (showInsideTriggerWarning)
            {
                EditorGUILayout.HelpBox(
                    "Inside Trigger should reference a Collider marked as Is Trigger.",
                    MessageType.Warning);
            }

            if (showUnsupportedInsideTriggerWarning)
            {
                EditorGUILayout.HelpBox(
                    $"Inside Trigger does not support {interactable.InsideTrigger.GetType().Name}. Use BoxCollider, SphereCollider, or CapsuleCollider.",
                    MessageType.Warning);
            }

        }

        private static void DrawHeader(string text)
        {
            EditorGUILayout.Space(6f);
            EditorGUILayout.LabelField(text, EditorStyles.boldLabel);
        }

        private void DrawPositionConstraintFields()
        {
            var hasMixedConstraintMode = _positionConstraintModeProp.hasMultipleDifferentValues;
            var constraintMode = (Interactable.PositionConstraintMode)_positionConstraintModeProp.enumValueIndex;
            if (hasMixedConstraintMode || constraintMode == Interactable.PositionConstraintMode.Radial)
            {
                EditorGUILayout.PropertyField(_minInteractionDistanceProp);
                EditorGUILayout.PropertyField(_maxInteractionDistanceProp);
            }
            else
            {
                EditorGUILayout.PropertyField(_maxPositionDeltaProp, new GUIContent("Max Distance"));
            }

            DrawMeasurementSpaceField();
            EditorGUILayout.PropertyField(_measurementAxisProp, new GUIContent("Measurement Axis"));
        }

        private void DrawMeasurementSpaceField()
        {
            var label = new GUIContent("Measurement Space");
            if (_measurementSpaceProp.hasMultipleDifferentValues)
            {
                EditorGUILayout.PropertyField(_measurementSpaceProp, label);
                return;
            }

            var selectedIndex = Mathf.Clamp(_measurementSpaceProp.enumValueIndex, 0, 1);
            var options = new[]
            {
                new GUIContent("World"),
                new GUIContent("Local")
            };

            var nextIndex = EditorGUILayout.Popup(label, selectedIndex, options);
            _measurementSpaceProp.enumValueIndex = nextIndex;
        }

        private void DrawInteractionHeader()
        {
            EditorGUILayout.Space(6f);

            var rect = EditorGUILayout.GetControlRect();
            var toggleRect = new Rect(rect.x, rect.y, 18f, rect.height);
            var labelRect = new Rect(toggleRect.xMax + 2f, rect.y, EditorGUIUtility.labelWidth, rect.height);

            EditorGUI.BeginProperty(toggleRect, GUIContent.none, _isEnabledProp);
            EditorGUI.showMixedValue = _isEnabledProp.hasMultipleDifferentValues;
            EditorGUI.BeginChangeCheck();
            var isEnabled = EditorGUI.Toggle(toggleRect, _isEnabledProp.boolValue);
            if (EditorGUI.EndChangeCheck())
            {
                _isEnabledProp.boolValue = isEnabled;
            }

            EditorGUI.showMixedValue = false;
            EditorGUI.EndProperty();

            EditorGUI.LabelField(labelRect, "Interaction", EditorStyles.boldLabel);
        }

        private static bool HasResolvableCollider(Interactable interactable)
        {
            if (interactable == null)
            {
                return false;
            }

            var current = interactable.transform;
            while (current != null)
            {
                if (current.GetComponentsInChildren<Collider>(true).Length > 0)
                {
                    return true;
                }

                current = current.parent;
            }

            return false;
        }

        private void OnSceneGUI()
        {
            var interactable = target as Interactable;
            if (interactable == null)
            {
                return;
            }

            DrawSceneGizmos(interactable);
        }

        private static void DrawSceneGizmos(Interactable interactable)
        {
            var referenceTransform = interactable.ReferenceTransform;
            if (referenceTransform == null || !interactable.IsEnabled)
            {
                return;
            }

            using (new Handles.DrawingScope(Matrix4x4.identity))
            {
                DrawReferenceTransform(interactable, referenceTransform);
                DrawCombinedConstraintFill(interactable, referenceTransform);
                DrawApproach(interactable, referenceTransform);
                DrawDistance(interactable, referenceTransform);
                DrawFacing(interactable, referenceTransform);
                DrawRaycastRequirement(interactable, referenceTransform);
                DrawFacingProbeHandle(interactable, referenceTransform);
            }
        }

        private static void DrawReferenceTransform(Interactable interactable, Transform referenceTransform)
        {
            Handles.color = AnchorColor;
            var handleSize = HandleUtility.GetHandleSize(referenceTransform.position) * 0.1f;
            Handles.SphereHandleCap(0, referenceTransform.position, referenceTransform.rotation, handleSize, UnityEngine.EventType.Repaint);
            var direction = interactable.ApproachNormal.normalized;
            if (direction.sqrMagnitude > Mathf.Epsilon)
            {
                Handles.DrawLine(referenceTransform.position, referenceTransform.position + direction * (handleSize * 4f), GizmoLineThickness);
            }

            if (interactable.transform != referenceTransform)
            {
                Handles.DrawDottedLine(interactable.transform.position, referenceTransform.position, 4f);
            }
        }

        private static void DrawApproach(Interactable interactable, Transform referenceTransform)
        {
            if (!interactable.RequireApproach)
            {
                return;
            }

            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider &&
                interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Radial)
            {
                return;
            }

            var minDistance = interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Radial
                ? Mathf.Max(0f, interactable.MinInteractionDistance)
                : 0f;
            var maxDistance = GetConstraintPreviewRadius(interactable, includeBoxConstraints: true);
            var forwardDirection = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);
            if (forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                if (IsSingleAxisMeasurement(interactable))
                {
                    DrawSingleAxisApproachPreview(interactable, referenceTransform, Vector3.zero, minDistance, maxDistance);
                }
                return;
            }

            if (IsSingleAxisMeasurement(interactable) && interactable.DistanceFrom != Interactable.DistanceFromMode.Collider)
            {
                DrawSingleAxisApproachPreview(interactable, referenceTransform, forwardDirection, minDistance, maxDistance);
                return;
            }

            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box && HasBoxConstraint(interactable))
            {
                DrawBoxConstrainedApproach(interactable, referenceTransform, forwardDirection, maxDistance);
                return;
            }

            if (interactable.MeasurementAxis == MoveAxis.XYZ)
            {
                DrawConeFrustum(referenceTransform.position,
                                forwardDirection,
                                interactable.MaxApproachAngle,
                                minDistance,
                                maxDistance,
                                ApproachColor);
                return;
            }

            if (!TryGetMeasurementArcNormal(interactable, referenceTransform, out var arcNormal))
            {
                DrawSingleAxisApproachStrip(interactable, referenceTransform, forwardDirection, maxDistance);
                return;
            }

            DrawAngularFan(referenceTransform.position,
                           forwardDirection,
                           arcNormal,
                           interactable.MaxApproachAngle,
                           minDistance,
                           maxDistance,
                           ApproachColor);
        }

        private static void DrawBoxConstrainedApproach(Interactable interactable,
                                                       Transform referenceTransform,
                                                       Vector3 forwardDirection,
                                                       float fallbackRadius)
        {
            var basis = GetMeasurementBasis(referenceTransform, interactable);
            var extents = GetBoxConstraintExtentsForGizmo(interactable, referenceTransform.position);
            var origin = referenceTransform.position;

            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    DrawBoxClippedPlanarApproach(origin,
                                                 basis,
                                                 extents,
                                                 basis.forward,
                                                 forwardDirection,
                                                 interactable.MaxApproachAngle);
                    break;
                case MoveAxis.XZ:
                    DrawBoxClippedPlanarApproach(origin,
                                                 basis,
                                                 extents,
                                                 basis.up,
                                                 forwardDirection,
                                                 interactable.MaxApproachAngle);
                    break;
                case MoveAxis.YZ:
                    DrawBoxClippedPlanarApproach(origin,
                                                 basis,
                                                 extents,
                                                 basis.right,
                                                 forwardDirection,
                                                 interactable.MaxApproachAngle);
                    break;
                case MoveAxis.XYZ:
                    DrawBoxClippedConeApproach(origin,
                                               basis,
                                               extents,
                                               forwardDirection,
                                               interactable.MaxApproachAngle);
                    break;
                default:
                    DrawSingleAxisApproachStrip(interactable, referenceTransform, forwardDirection, fallbackRadius);
                    break;
            }
        }

        private static void DrawCombinedConstraintFill(Interactable interactable, Transform referenceTransform)
        {
            if (Event.current.type != UnityEngine.EventType.Repaint)
            {
                return;
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);
            var forwardDirection = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);

            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box)
            {
                if (!interactable.RequireApproach)
                {
                    return;
                }

                if (forwardDirection.sqrMagnitude <= Mathf.Epsilon)
                {
                    return;
                }

                if (!HasBoxConstraint(interactable))
                {
                    return;
                }

                var extents = GetBoxConstraintExtentsForGizmo(interactable, referenceTransform.position);
                DrawBoxConstrainedFill(referenceTransform.position,
                                       basis,
                                       extents,
                                       forwardDirection,
                                       interactable.MaxApproachAngle,
                                       interactable.MeasurementAxis,
                                       CombinedConstraintFillColor);
                return;
            }

            if (interactable.PositionDistanceMode != Interactable.PositionConstraintMode.Radial)
            {
                return;
            }

            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider)
            {
                switch (interactable.MeasurementAxis)
                {
                    case MoveAxis.XY:
                        DrawColliderPlanarSectorFill(interactable, referenceTransform, basis.forward, forwardDirection, CombinedConstraintFillColor);
                        break;
                    case MoveAxis.XZ:
                        DrawColliderPlanarSectorFill(interactable, referenceTransform, basis.up, forwardDirection, CombinedConstraintFillColor);
                        break;
                    case MoveAxis.YZ:
                        DrawColliderPlanarSectorFill(interactable, referenceTransform, basis.right, forwardDirection, CombinedConstraintFillColor);
                        break;
                    case MoveAxis.XYZ:
                        DrawColliderSphericalFill(interactable, referenceTransform, basis, forwardDirection, CombinedConstraintFillColor);
                        break;
                }

                return;
            }

            var maxDistance = interactable.MaxInteractionDistance;
            if (maxDistance <= 0f)
            {
                return;
            }

            if (!interactable.RequireApproach)
            {
                return;
            }

            if (forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var minDistance = Mathf.Max(0f, interactable.MinInteractionDistance);
            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    DrawPlanarSectorFill(referenceTransform.position,
                                         basis.forward,
                                         forwardDirection,
                                         interactable.MaxApproachAngle,
                                         minDistance,
                                         maxDistance,
                                         CombinedConstraintFillColor);
                    break;
                case MoveAxis.XZ:
                    DrawPlanarSectorFill(referenceTransform.position,
                                         basis.up,
                                         forwardDirection,
                                         interactable.MaxApproachAngle,
                                         minDistance,
                                         maxDistance,
                                         CombinedConstraintFillColor);
                    break;
                case MoveAxis.YZ:
                    DrawPlanarSectorFill(referenceTransform.position,
                                         basis.right,
                                         forwardDirection,
                                         interactable.MaxApproachAngle,
                                         minDistance,
                                         maxDistance,
                                         CombinedConstraintFillColor);
                    break;
                case MoveAxis.XYZ:
                    DrawSphericalConeFill(referenceTransform.position,
                                          forwardDirection.normalized,
                                          interactable.MaxApproachAngle,
                                          minDistance,
                                          maxDistance,
                                          CombinedConstraintFillColor);
                    break;
            }
        }


        private static void DrawDistance(Interactable interactable, Transform referenceTransform)
        {
            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Radial)
            {
                if (interactable.RequireApproach &&
                    IsSingleAxisMeasurement(interactable) &&
                    interactable.DistanceFrom != Interactable.DistanceFromMode.Collider)
                {
                    return;
                }

                if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider)
                {
                    DrawColliderRadialDistanceConstraint(interactable, referenceTransform);
                }
                else
                {
                    DrawRadialDistanceConstraint(interactable, referenceTransform);
                }
            }
            else
            {
                DrawBoxDistanceConstraint(interactable, referenceTransform);
            }

            if (interactable.DistanceFrom != Interactable.DistanceFromMode.Collider)
            {
                return;
            }

            Handles.color = DistanceColor;
            foreach (var collider in interactable.GetComponentsInChildren<Collider>(true))
            {
                var bounds = collider.bounds;
                if (bounds.size.sqrMagnitude <= Mathf.Epsilon)
                {
                    continue;
                }

                Handles.DrawWireCube(bounds.center, bounds.size);
            }
        }

        private static void DrawSingleAxisApproachPreview(Interactable interactable,
                                                          Transform referenceTransform,
                                                          Vector3 forwardDirection,
                                                          float minDistance,
                                                          float maxDistance)
        {
            var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
            if (axisDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var effectiveMax = GetSingleAxisPreviewMaxDistance(interactable, referenceTransform, maxDistance);
            if (effectiveMax <= 0f)
            {
                return;
            }

            var widthDirection = GetSingleAxisWidthDirection(referenceTransform.position, axisDirection, referenceTransform, interactable);
            var halfWidth = GetSingleAxisStripHalfWidth(interactable, axisDirection, widthDirection, referenceTransform.position);

            if (forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                DrawSingleAxisCenteredStrip(interactable,
                                            referenceTransform,
                                            effectiveMax,
                                            ApproachFillColor,
                                            ApproachColor);
                return;
            }

            var directionSign = Mathf.Sign(Vector3.Dot(forwardDirection.normalized, axisDirection));
            if (Mathf.Approximately(directionSign, 0f))
            {
                DrawSingleAxisCenteredStrip(interactable,
                                            referenceTransform,
                                            effectiveMax,
                                            ApproachFillColor,
                                            ApproachColor);
                return;
            }

            var startDistance = Mathf.Min(directionSign * Mathf.Max(0f, minDistance), directionSign * effectiveMax);
            var endDistance = Mathf.Max(directionSign * Mathf.Max(0f, minDistance), directionSign * effectiveMax);

            DrawStrip(referenceTransform.position,
                      axisDirection,
                      widthDirection,
                      startDistance,
                      endDistance,
                      halfWidth,
                      ApproachFillColor,
                      ApproachColor);

            if (minDistance > 0f)
            {
                Handles.color = MinDistanceColor;
                var boundaryPoint = referenceTransform.position + axisDirection * (directionSign * minDistance);
                DrawSingleAxisBoundaryMarker(boundaryPoint, axisDirection, referenceTransform.position);
            }
        }

        private static float GetSingleAxisPreviewMaxDistance(Interactable interactable,
                                                             Transform referenceTransform,
                                                             float maxDistance)
        {
            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box)
            {
                var maxPositionDelta = interactable.MaxPositionDelta;
                var axisExtent = interactable.MeasurementAxis switch
                {
                    MoveAxis.X => maxPositionDelta.x,
                    MoveAxis.Y => maxPositionDelta.y,
                    MoveAxis.Z => maxPositionDelta.z,
                    _ => 0f
                };

                if (axisExtent > 0f)
                {
                    return axisExtent;
                }
            }

            if (maxDistance > 0f)
            {
                return maxDistance;
            }

            return GetConstraintPreviewRadius(interactable, includeBoxConstraints: true);
        }

        private static void DrawColliderRadialDistanceConstraint(Interactable interactable, Transform referenceTransform)
        {
            var minDistance = interactable.MinInteractionDistance;
            var maxDistance = interactable.MaxInteractionDistance;

            if (minDistance <= 0f && maxDistance <= 0f)
            {
                return;
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);
            var hasApproach = interactable.RequireApproach;
            var forwardDirection = hasApproach
                ? ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal)
                : Vector3.zero;

            if (maxDistance > 0f)
            {
                Handles.color = DistanceColor;
                DrawColliderDistanceBoundary(interactable, referenceTransform, basis, forwardDirection, hasApproach, maxDistance);
            }

            if (minDistance > 0f)
            {
                Handles.color = MinDistanceColor;
                DrawColliderDistanceBoundary(interactable, referenceTransform, basis, forwardDirection, hasApproach, minDistance);
            }
        }

        private static void DrawFacing(Interactable interactable, Transform referenceTransform)
        {
            if (!interactable.RequireFacing)
            {
                return;
            }

            if (!TryGetFacingPreview(interactable, referenceTransform, out var previewPoint, out var facingDirection))
            {
                return;
            }

            var previewColor = IsFacingPreviewPositionValid(interactable, referenceTransform, previewPoint)
                ? FacingColor
                : InvalidConstraintColor;
            var previewRadius = GetFacingPreviewRadius(interactable, previewPoint);

            if (interactable.MeasurementAxis == MoveAxis.XYZ)
            {
                DrawConeFrustum(previewPoint,
                                facingDirection,
                                interactable.MaxFacingAngle,
                                0f,
                                previewRadius,
                                previewColor);
                return;
            }

            if (!TryGetFacingArcNormal(interactable, referenceTransform, facingDirection, out var arcNormal))
            {
                return;
            }

            Handles.color = previewColor;
            DrawAngularFan(previewPoint,
                           facingDirection,
                           arcNormal,
                           interactable.MaxFacingAngle,
                           0f,
                           previewRadius,
                           previewColor);
        }

        private static void DrawRaycastRequirement(Interactable interactable, Transform referenceTransform)
        {
            if (!interactable.RequireRaycastHit)
            {
                return;
            }

            if (!TryGetFacingPreview(interactable, referenceTransform, out var previewPoint, out _))
            {
                var outwardDirection = GetFacingPreviewDirection(interactable, referenceTransform);
                if (outwardDirection.sqrMagnitude <= Mathf.Epsilon)
                {
                    return;
                }

                var fallbackDistance = GetConstraintPreviewRadius(interactable, includeBoxConstraints: true) * 0.75f;
                if (fallbackDistance <= 0f)
                {
                    return;
                }

                previewPoint = referenceTransform.position + outwardDirection.normalized * fallbackDistance;
            }

            Handles.color = IsFacingPreviewPositionValid(interactable, referenceTransform, previewPoint)
                ? DistanceColor
                : InvalidConstraintColor;
            Handles.DrawDottedLine(previewPoint, referenceTransform.position, 4f);
        }

        private static void DrawFacingProbeHandle(Interactable interactable, Transform referenceTransform)
        {
            if (!interactable.RequireFacing)
            {
                return;
            }

            if (!TryGetFacingPreview(interactable, referenceTransform, out var previewPoint, out _))
            {
                return;
            }

            var isValid = IsFacingPreviewPositionValid(interactable, referenceTransform, previewPoint);
            var handleSize = HandleUtility.GetHandleSize(previewPoint) * 0.08f;
            Handles.color = isValid ? FacingColor : InvalidConstraintColor;

            EditorGUI.BeginChangeCheck();
            var newPreviewPoint = Handles.FreeMoveHandle(previewPoint,
                                                         handleSize,
                                                         Vector3.zero,
                                                         Handles.SphereHandleCap);
            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            FacingPreviewOverrides[interactable.GetTransientId()] = newPreviewPoint;
        }

        private static void DrawRadialDistanceConstraint(Interactable interactable, Transform referenceTransform)
        {
            var minDistance = interactable.MinInteractionDistance;
            var maxDistance = interactable.MaxInteractionDistance;

            if (minDistance <= 0f && maxDistance <= 0f)
            {
                return;
            }

            if (IsSingleAxisMeasurement(interactable))
            {
                DrawSingleAxisRadialDistanceConstraint(interactable, referenceTransform, minDistance, maxDistance);
                return;
            }

            if (interactable.RequireApproach)
            {
                DrawRadialDistanceConstraintInsideApproach(interactable, referenceTransform, minDistance, maxDistance);
                return;
            }

            Handles.color = DistanceColor;
            DrawRadialDistanceShape(interactable, referenceTransform, maxDistance);

            if (minDistance > 0f)
            {
                Handles.color = MinDistanceColor;
                DrawRadialDistanceShape(interactable, referenceTransform, minDistance);
            }
        }

        private static void DrawRadialDistanceConstraintInsideApproach(Interactable interactable,
                                                                       Transform referenceTransform,
                                                                       float minDistance,
                                                                       float maxDistance)
        {
            if (IsSingleAxisMeasurement(interactable))
            {
                DrawSingleAxisConstrainedDistanceConstraint(interactable, referenceTransform, minDistance, maxDistance);
                return;
            }

            var forwardDirection = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);
            if (forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                Handles.color = DistanceColor;
                DrawRadialDistanceShape(interactable, referenceTransform, maxDistance);

                if (minDistance > 0f)
                {
                    Handles.color = MinDistanceColor;
                    DrawRadialDistanceShape(interactable, referenceTransform, minDistance);
                }

                return;
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);

            if (maxDistance > 0f)
            {
                Handles.color = DistanceColor;
                DrawConstrainedRadialDistanceShape(interactable,
                                                   referenceTransform.position,
                                                   basis,
                                                   forwardDirection,
                                                   interactable.MaxApproachAngle,
                                                   maxDistance);
            }

            if (minDistance > 0f)
            {
                Handles.color = MinDistanceColor;
                DrawConstrainedRadialDistanceShape(interactable,
                                                   referenceTransform.position,
                                                   basis,
                                                   forwardDirection,
                                                   interactable.MaxApproachAngle,
                                                   minDistance);
            }
        }

        private static void DrawSingleAxisRadialDistanceConstraint(Interactable interactable,
                                                                   Transform referenceTransform,
                                                                   float minDistance,
                                                                   float maxDistance)
        {
            var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
            if (axisDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var effectiveMax = maxDistance > 0f ? maxDistance : Mathf.Max(minDistance, GetConstraintPreviewRadius(interactable, includeBoxConstraints: true));
            if (effectiveMax <= 0f)
            {
                return;
            }

            Handles.color = DistanceColor;
            if (minDistance > 0f)
            {
                DrawSingleAxisDistanceSegment(referenceTransform.position, axisDirection, minDistance, effectiveMax);
                DrawSingleAxisDistanceSegment(referenceTransform.position, -axisDirection, minDistance, effectiveMax);

                Handles.color = MinDistanceColor;
                DrawSingleAxisBoundaryMarker(referenceTransform.position + axisDirection * minDistance, axisDirection, referenceTransform.position);
                DrawSingleAxisBoundaryMarker(referenceTransform.position - axisDirection * minDistance, axisDirection, referenceTransform.position);
                return;
            }

            Handles.DrawLine(referenceTransform.position - axisDirection * effectiveMax,
                             referenceTransform.position + axisDirection * effectiveMax,
                             GizmoLineThickness);
        }

        private static void DrawSingleAxisConstrainedDistanceConstraint(Interactable interactable,
                                                                        Transform referenceTransform,
                                                                        float minDistance,
                                                                        float maxDistance)
        {
            var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
            var forwardDirection = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);
            if (axisDirection.sqrMagnitude <= Mathf.Epsilon || forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                DrawSingleAxisRadialDistanceConstraint(interactable, referenceTransform, minDistance, maxDistance);
                return;
            }

            var alignment = Vector3.Dot(axisDirection, forwardDirection.normalized);
            var effectiveMax = maxDistance > 0f ? maxDistance : Mathf.Max(minDistance, GetConstraintPreviewRadius(interactable, includeBoxConstraints: true));
            if (effectiveMax <= 0f)
            {
                return;
            }

            Handles.color = DistanceColor;
            if (alignment > 0f)
            {
                DrawSingleAxisDistanceSegment(referenceTransform.position, axisDirection, Mathf.Max(0f, minDistance), effectiveMax);
                if (minDistance > 0f)
                {
                    Handles.color = MinDistanceColor;
                    DrawSingleAxisBoundaryMarker(referenceTransform.position + axisDirection * minDistance, axisDirection, referenceTransform.position);
                }
                return;
            }

            if (alignment < 0f)
            {
                DrawSingleAxisDistanceSegment(referenceTransform.position, -axisDirection, Mathf.Max(0f, minDistance), effectiveMax);
                if (minDistance > 0f)
                {
                    Handles.color = MinDistanceColor;
                    DrawSingleAxisBoundaryMarker(referenceTransform.position - axisDirection * minDistance, axisDirection, referenceTransform.position);
                }
                return;
            }

            DrawSingleAxisRadialDistanceConstraint(interactable, referenceTransform, minDistance, maxDistance);
        }

        private static void DrawSingleAxisDistanceSegment(Vector3 origin,
                                                          Vector3 direction,
                                                          float startDistance,
                                                          float endDistance)
        {
            if (direction.sqrMagnitude <= Mathf.Epsilon || endDistance <= startDistance)
            {
                return;
            }

            Handles.DrawLine(origin + direction * startDistance,
                             origin + direction * endDistance,
                             GizmoLineThickness);
        }

        private static void DrawSingleAxisBoundaryMarker(Vector3 point, Vector3 axisDirection, Vector3 referencePosition)
        {
            var widthDirection = Vector3.Cross(axisDirection.normalized, Vector3.up);
            if (widthDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                widthDirection = Vector3.Cross(axisDirection.normalized, Vector3.right);
            }

            if (widthDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                var sceneView = SceneView.currentDrawingSceneView;
                if (sceneView != null && sceneView.camera != null)
                {
                    widthDirection = Vector3.Cross(axisDirection.normalized, sceneView.camera.transform.forward);
                }
            }

            widthDirection = widthDirection.sqrMagnitude > Mathf.Epsilon ? widthDirection.normalized : Vector3.right;
            var markerHalfWidth = Mathf.Max(HandleUtility.GetHandleSize(point) * 0.08f, 0.04f);
            Handles.DrawLine(point - widthDirection * markerHalfWidth,
                             point + widthDirection * markerHalfWidth,
                             GizmoLineThickness);
        }

        private static void DrawRadialDistanceShape(Interactable interactable, Transform referenceTransform, float distance)
        {
            if (distance <= 0f)
            {
                return;
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);
            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    DrawFilledDisc(referenceTransform.position, basis.forward, distance);
                    break;
                case MoveAxis.XZ:
                    DrawFilledDisc(referenceTransform.position, basis.up, distance);
                    break;
                case MoveAxis.YZ:
                    DrawFilledDisc(referenceTransform.position, basis.right, distance);
                    break;
                case MoveAxis.X:
                case MoveAxis.Y:
                case MoveAxis.Z:
                {
                    var axisDirection = GetSingleAxisDirection(referenceTransform, interactable);
                    Handles.DrawLine(referenceTransform.position - axisDirection * distance,
                                     referenceTransform.position + axisDirection * distance,
                                     GizmoLineThickness);
                    break;
                }
                case MoveAxis.XYZ:
                default:
                {
                    DrawFilledSphere(referenceTransform.position, distance);
                    Handles.DrawWireDisc(referenceTransform.position, basis.up, distance);
                    Handles.DrawWireDisc(referenceTransform.position, basis.right, distance);
                    Handles.DrawWireDisc(referenceTransform.position, basis.forward, distance);
                    break;
                }
            }
        }

        private static void DrawFilledSphere(Vector3 center, float radius)
        {
            if (radius <= 0f)
            {
                return;
            }

            var outlineColor = Handles.color;
            var fillColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, DistanceFillColor.a);
            using (new Handles.DrawingScope(fillColor))
            {
                var previousZTest = Handles.zTest;
                Handles.zTest = CompareFunction.LessEqual;
                Handles.SphereHandleCap(0, center, Quaternion.identity, radius * 2f, UnityEngine.EventType.Repaint);
                Handles.zTest = previousZTest;
            }
        }

        private static void DrawFilledDisc(Vector3 center, Vector3 normal, float radius)
        {
            if (normal.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var outlineColor = Handles.color;
            var fillColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, DistanceFillColor.a);
            using (new Handles.DrawingScope(fillColor))
            {
                var previousZTest = Handles.zTest;
                Handles.zTest = CompareFunction.Always;
                Handles.DrawSolidDisc(center, normal.normalized, radius);
                Handles.zTest = previousZTest;
            }

            Handles.DrawWireDisc(center, normal.normalized, radius);
        }

        private static void DrawSphericalConeFill(Vector3 origin,
                                                  Vector3 forwardDirection,
                                                  float maxAngle,
                                                  float minRadius,
                                                  float maxRadius,
                                                  Color color)
        {
            if (maxRadius <= 0f || forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            EnsureConstraintFillResources();
            if (_constraintFillMaterial == null || _constraintFillMesh == null)
            {
                return;
            }

            ConstraintFillVertices.Clear();
            ConstraintFillTriangles.Clear();

            GetConeFrame(forwardDirection, out var right, out var up);

            var clampedMaxAngle = Mathf.Clamp(maxAngle, 0f, 180f);
            AddSphericalPatch(origin, forwardDirection, right, up, maxRadius, 0f, clampedMaxAngle, outward: true);

            if (minRadius > 0f)
            {
                AddSphericalPatch(origin, forwardDirection, right, up, minRadius, 0f, clampedMaxAngle, outward: false);
            }

            AddConeBoundarySurface(origin, forwardDirection, right, up, clampedMaxAngle, minRadius, maxRadius);

            _constraintFillMesh.Clear();
            _constraintFillMesh.SetVertices(ConstraintFillVertices);
            _constraintFillMesh.SetTriangles(ConstraintFillTriangles, 0);
            _constraintFillMesh.RecalculateBounds();
            _constraintFillMesh.RecalculateNormals();

            _constraintFillMaterial.SetColor("_Color", color);
            _constraintFillMaterial.SetPass(0);
            Graphics.DrawMeshNow(_constraintFillMesh, Matrix4x4.identity);
        }

        private static void DrawPlanarSectorFill(Vector3 origin,
                                                 Vector3 planeNormal,
                                                 Vector3 forwardDirection,
                                                 float maxAngle,
                                                 float minRadius,
                                                 float maxRadius,
                                                 Color color)
        {
            if (maxRadius <= 0f || planeNormal.sqrMagnitude <= Mathf.Epsilon || forwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var tangent = Vector3.ProjectOnPlane(forwardDirection, planeNormal);
            if (tangent.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            EnsureConstraintFillResources();
            if (_constraintFillMaterial == null || _constraintFillMesh == null)
            {
                return;
            }

            tangent.Normalize();
            var normal = planeNormal.normalized;
            var clampedMaxAngle = Mathf.Clamp(maxAngle, 0f, 180f);
            var startDirection = Quaternion.AngleAxis(-clampedMaxAngle, normal) * tangent;

            ConstraintFillVertices.Clear();
            ConstraintFillTriangles.Clear();

            if (minRadius > 0f)
            {
                for (var index = 0; index <= PlanarFillArcSegments; index++)
                {
                    var t = index / (float)PlanarFillArcSegments;
                    var angle = clampedMaxAngle * 2f * t;
                    var direction = Quaternion.AngleAxis(angle, normal) * startDirection;
                    ConstraintFillVertices.Add(origin + direction * minRadius);
                    ConstraintFillVertices.Add(origin + direction * maxRadius);
                }

                for (var index = 0; index < PlanarFillArcSegments; index++)
                {
                    var a = index * 2;
                    var b = a + 1;
                    var c = a + 2;
                    var d = a + 3;

                    ConstraintFillTriangles.Add(a);
                    ConstraintFillTriangles.Add(b);
                    ConstraintFillTriangles.Add(c);
                    ConstraintFillTriangles.Add(b);
                    ConstraintFillTriangles.Add(d);
                    ConstraintFillTriangles.Add(c);
                }
            }
            else
            {
                ConstraintFillVertices.Add(origin);
                for (var index = 0; index <= PlanarFillArcSegments; index++)
                {
                    var t = index / (float)PlanarFillArcSegments;
                    var angle = clampedMaxAngle * 2f * t;
                    var direction = Quaternion.AngleAxis(angle, normal) * startDirection;
                    ConstraintFillVertices.Add(origin + direction * maxRadius);
                }

                for (var index = 1; index <= PlanarFillArcSegments; index++)
                {
                    ConstraintFillTriangles.Add(0);
                    ConstraintFillTriangles.Add(index);
                    ConstraintFillTriangles.Add(index + 1);
                }
            }

            _constraintFillMesh.Clear();
            _constraintFillMesh.SetVertices(ConstraintFillVertices);
            _constraintFillMesh.SetTriangles(ConstraintFillTriangles, 0);
            _constraintFillMesh.RecalculateBounds();
            _constraintFillMesh.RecalculateNormals();

            _constraintFillMaterial.SetColor("_Color", color);
            _constraintFillMaterial.SetPass(0);
            Graphics.DrawMeshNow(_constraintFillMesh, Matrix4x4.identity);
        }

        private static void EnsureConstraintFillResources()
        {
            if (_constraintFillMaterial == null)
            {
                var shader = Shader.Find("Hidden/Internal-Colored");
                if (shader == null)
                {
                    return;
                }

                _constraintFillMaterial = new Material(shader)
                {
                    hideFlags = HideFlags.HideAndDontSave
                };
                _constraintFillMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
                _constraintFillMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
                _constraintFillMaterial.SetInt("_Cull", (int)CullMode.Off);
                _constraintFillMaterial.SetInt("_ZWrite", 0);
                _constraintFillMaterial.SetInt("_ZTest", (int)CompareFunction.LessEqual);
            }

            if (_constraintFillMesh == null)
            {
                _constraintFillMesh = new Mesh
                {
                    hideFlags = HideFlags.HideAndDontSave,
                    name = "InteractableConstraintFill"
                };
            }
        }

        private static void AddSphericalPatch(Vector3 origin,
                                              Vector3 forwardDirection,
                                              Vector3 right,
                                              Vector3 up,
                                              float radius,
                                              float minAngle,
                                              float maxAngle,
                                              bool outward)
        {
            if (radius <= 0f)
            {
                return;
            }

            var startVertex = ConstraintFillVertices.Count;
            for (var polarIndex = 0; polarIndex <= ConeFillPolarSegments; polarIndex++)
            {
                var polarT = polarIndex / (float)ConeFillPolarSegments;
                var polarAngle = Mathf.Lerp(minAngle, maxAngle, polarT) * Mathf.Deg2Rad;
                var sinPolar = Mathf.Sin(polarAngle);
                var cosPolar = Mathf.Cos(polarAngle);

                for (var radialIndex = 0; radialIndex <= ConeFillRadialSegments; radialIndex++)
                {
                    var azimuthT = radialIndex / (float)ConeFillRadialSegments;
                    var azimuth = azimuthT * Mathf.PI * 2f;
                    var ringDirection = right * Mathf.Cos(azimuth) + up * Mathf.Sin(azimuth);
                    var direction = forwardDirection * cosPolar + ringDirection * sinPolar;
                    ConstraintFillVertices.Add(origin + direction * radius);
                }
            }

            AddGridTriangles(startVertex,
                             ConeFillPolarSegments + 1,
                             ConeFillRadialSegments + 1,
                             outward);
        }

        private static void AddConeBoundarySurface(Vector3 origin,
                                                   Vector3 forwardDirection,
                                                   Vector3 right,
                                                   Vector3 up,
                                                   float angle,
                                                   float minRadius,
                                                   float maxRadius)
        {
            if (maxRadius <= 0f)
            {
                return;
            }

            var angleRadians = angle * Mathf.Deg2Rad;
            var sinAngle = Mathf.Sin(angleRadians);
            var cosAngle = Mathf.Cos(angleRadians);
            var startVertex = ConstraintFillVertices.Count;

            for (var radiusIndex = 0; radiusIndex <= 1; radiusIndex++)
            {
                var radius = radiusIndex == 0 ? minRadius : maxRadius;
                for (var radialIndex = 0; radialIndex <= ConeFillRadialSegments; radialIndex++)
                {
                    var azimuthT = radialIndex / (float)ConeFillRadialSegments;
                    var azimuth = azimuthT * Mathf.PI * 2f;
                    var ringDirection = right * Mathf.Cos(azimuth) + up * Mathf.Sin(azimuth);
                    var direction = forwardDirection * cosAngle + ringDirection * sinAngle;
                    ConstraintFillVertices.Add(origin + direction * radius);
                }
            }

            AddGridTriangles(startVertex, 2, ConeFillRadialSegments + 1, outward: true);
        }

        private static void AddGridTriangles(int startVertex, int rows, int columns, bool outward)
        {
            for (var row = 0; row < rows - 1; row++)
            {
                for (var column = 0; column < columns - 1; column++)
                {
                    var a = startVertex + row * columns + column;
                    var b = a + 1;
                    var c = a + columns;
                    var d = c + 1;

                    if (outward)
                    {
                        ConstraintFillTriangles.Add(a);
                        ConstraintFillTriangles.Add(c);
                        ConstraintFillTriangles.Add(b);
                        ConstraintFillTriangles.Add(b);
                        ConstraintFillTriangles.Add(c);
                        ConstraintFillTriangles.Add(d);
                    }
                    else
                    {
                        ConstraintFillTriangles.Add(a);
                        ConstraintFillTriangles.Add(b);
                        ConstraintFillTriangles.Add(c);
                        ConstraintFillTriangles.Add(b);
                        ConstraintFillTriangles.Add(d);
                        ConstraintFillTriangles.Add(c);
                    }
                }
            }
        }

        private static void DrawConstrainedRadialDistanceShape(Interactable interactable,
                                                               Vector3 center,
                                                               (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                               Vector3 forwardDirection,
                                                               float maxAngle,
                                                               float distance)
        {
            if (distance <= 0f)
            {
                return;
            }

            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    DrawDistanceArc(center, basis.forward, forwardDirection, maxAngle, distance);
                    break;
                case MoveAxis.XZ:
                    DrawDistanceArc(center, basis.up, forwardDirection, maxAngle, distance);
                    break;
                case MoveAxis.YZ:
                    DrawDistanceArc(center, basis.right, forwardDirection, maxAngle, distance);
                    break;
                case MoveAxis.X:
                case MoveAxis.Y:
                case MoveAxis.Z:
                {
                    var axisDirection = GetSingleAxisDirectionFromBasis(interactable.MeasurementAxis, basis);
                    var alignment = Vector3.Dot(axisDirection.normalized, forwardDirection.normalized);
                    if (alignment > 0f)
                    {
                        Handles.DrawLine(center, center + axisDirection.normalized * distance, GizmoLineThickness);
                    }
                    else if (alignment < 0f)
                    {
                        Handles.DrawLine(center, center - axisDirection.normalized * distance, GizmoLineThickness);
                    }
                    else
                    {
                        Handles.DrawLine(center - axisDirection.normalized * distance,
                                         center + axisDirection.normalized * distance,
                                         GizmoLineThickness);
                    }
                    break;
                }
                case MoveAxis.XYZ:
                default:
                    DrawDistanceArc(center, basis.up, forwardDirection, maxAngle, distance);
                    DrawDistanceArc(center, basis.right, forwardDirection, maxAngle, distance);
                    DrawDistanceArc(center, basis.forward, forwardDirection, maxAngle, distance);
                    break;
            }
        }

        private static void DrawDistanceArc(Vector3 center,
                                            Vector3 planeNormal,
                                            Vector3 forwardDirection,
                                            float maxAngle,
                                            float radius)
        {
            var normal = planeNormal.normalized;
            if (normal.sqrMagnitude <= Mathf.Epsilon || forwardDirection.sqrMagnitude <= Mathf.Epsilon || radius <= 0f)
            {
                return;
            }

            var tangent = Vector3.ProjectOnPlane(forwardDirection, normal);
            if (tangent.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            tangent.Normalize();
            var startDirection = Quaternion.AngleAxis(-maxAngle, normal) * tangent;
            Handles.DrawWireArc(center, normal, startDirection, maxAngle * 2f, radius);
        }

        private static void DrawColliderPlanarSectorFill(Interactable interactable,
                                                         Transform referenceTransform,
                                                         Vector3 planeNormal,
                                                         Vector3 forwardDirection,
                                                         Color color)
        {
            var maxDistance = interactable.MaxInteractionDistance;
            if (maxDistance <= 0f)
            {
                return;
            }

            if (!TryBuildColliderBoundaryPoints(interactable,
                                                referenceTransform,
                                                planeNormal,
                                                forwardDirection,
                                                sectorLimited: interactable.RequireApproach,
                                                boundaryDistance: maxDistance,
                                                out var outerPoints))
            {
                return;
            }

            List<Vector3> innerPoints = null;
            var minDistance = Mathf.Max(0f, interactable.MinInteractionDistance);
            if (!TryBuildColliderBoundaryPoints(interactable,
                                                referenceTransform,
                                                planeNormal,
                                                forwardDirection,
                                                sectorLimited: interactable.RequireApproach,
                                                boundaryDistance: minDistance,
                                                out innerPoints))
            {
                return;
            }

            DrawBoundaryStripFill(innerPoints, outerPoints, color, closeLoop: !interactable.RequireApproach);
        }

        private static void DrawColliderSphericalFill(Interactable interactable,
                                                      Transform referenceTransform,
                                                      (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                      Vector3 forwardDirection,
                                                      Color color)
        {
            var maxDistance = interactable.MaxInteractionDistance;
            if (maxDistance <= 0f)
            {
                return;
            }

            EnsureConstraintFillResources();
            if (_constraintFillMaterial == null || _constraintFillMesh == null)
            {
                return;
            }

            ConstraintFillVertices.Clear();
            ConstraintFillTriangles.Clear();

            var shellForward = interactable.RequireApproach && forwardDirection.sqrMagnitude > Mathf.Epsilon
                ? forwardDirection.normalized
                : (basis.forward.sqrMagnitude > Mathf.Epsilon ? basis.forward.normalized : referenceTransform.forward);
            GetConeFrame(shellForward, out var shellRight, out var shellUp);

            var polarMax = interactable.RequireApproach ? interactable.MaxApproachAngle : 180f;
            var innerDistance = Mathf.Max(0f, interactable.MinInteractionDistance);

            AddColliderSphericalPatch(interactable,
                                      referenceTransform,
                                      shellForward,
                                      shellRight,
                                      shellUp,
                                      maxDistance,
                                      0f,
                                      polarMax,
                                      outward: true);

            AddColliderSphericalPatch(interactable,
                                      referenceTransform,
                                      shellForward,
                                      shellRight,
                                      shellUp,
                                      innerDistance,
                                      0f,
                                      polarMax,
                                      outward: false);

            if (interactable.RequireApproach && polarMax < 180f)
            {
                AddColliderPolarBoundarySurface(interactable,
                                               referenceTransform,
                                               shellForward,
                                               shellRight,
                                               shellUp,
                                               polarMax,
                                               innerDistance,
                                               maxDistance);
            }

            _constraintFillMesh.Clear();
            _constraintFillMesh.SetVertices(ConstraintFillVertices);
            _constraintFillMesh.SetTriangles(ConstraintFillTriangles, 0);
            _constraintFillMesh.RecalculateBounds();
            _constraintFillMesh.RecalculateNormals();

            _constraintFillMaterial.SetColor("_Color", color);
            _constraintFillMaterial.SetPass(0);
            Graphics.DrawMeshNow(_constraintFillMesh, Matrix4x4.identity);
        }

        private static void DrawColliderDistanceBoundary(Interactable interactable,
                                                         Transform referenceTransform,
                                                         (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                         Vector3 forwardDirection,
                                                         bool sectorLimited,
                                                         float boundaryDistance)
        {
            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.forward, forwardDirection, sectorLimited, boundaryDistance);
                    break;
                case MoveAxis.XZ:
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.up, forwardDirection, sectorLimited, boundaryDistance);
                    break;
                case MoveAxis.YZ:
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.right, forwardDirection, sectorLimited, boundaryDistance);
                    break;
                case MoveAxis.XYZ:
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.up, forwardDirection, sectorLimited, boundaryDistance);
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.right, forwardDirection, sectorLimited, boundaryDistance);
                    DrawColliderDistanceBoundaryLoop(interactable, referenceTransform, basis.forward, forwardDirection, sectorLimited, boundaryDistance);
                    break;
                case MoveAxis.X:
                case MoveAxis.Y:
                case MoveAxis.Z:
                {
                    var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
                    DrawColliderDistanceLine(interactable, referenceTransform, axisDirection, boundaryDistance);
                    break;
                }
            }
        }

        private static void DrawColliderDistanceBoundaryLoop(Interactable interactable,
                                                             Transform referenceTransform,
                                                             Vector3 planeNormal,
                                                             Vector3 forwardDirection,
                                                             bool sectorLimited,
                                                             float boundaryDistance)
        {
            if (!TryBuildColliderBoundaryPoints(interactable,
                                                referenceTransform,
                                                planeNormal,
                                                forwardDirection,
                                                sectorLimited,
                                                boundaryDistance,
                                                out var points))
            {
                return;
            }

            if (!sectorLimited)
            {
                points.Add(points[0]);
            }

            Handles.DrawAAPolyLine(GizmoLineThickness, points.ToArray());
        }

        private static void DrawColliderDistanceLine(Interactable interactable,
                                                     Transform referenceTransform,
                                                     Vector3 axisDirection,
                                                     float boundaryDistance)
        {
            if (boundaryDistance <= 0f || axisDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var origin = referenceTransform.position;
            if (TrySolveColliderBoundaryPoint(interactable, referenceTransform, axisDirection, boundaryDistance, out var positivePoint))
            {
                Handles.DrawLine(origin, positivePoint, GizmoLineThickness);
            }

            if (TrySolveColliderBoundaryPoint(interactable, referenceTransform, -axisDirection, boundaryDistance, out var negativePoint))
            {
                Handles.DrawLine(origin, negativePoint, GizmoLineThickness);
            }
        }

        private static bool TryBuildColliderBoundaryPoints(Interactable interactable,
                                                           Transform referenceTransform,
                                                           Vector3 planeNormal,
                                                           Vector3 forwardDirection,
                                                           bool sectorLimited,
                                                           float boundaryDistance,
                                                           out List<Vector3> points)
        {
            points = new List<Vector3>(BoxConeArcSegments + 1);
            var normal = planeNormal.normalized;
            if (normal.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            Vector3 startDirection;
            float totalAngle;

            if (sectorLimited)
            {
                var tangent = Vector3.ProjectOnPlane(forwardDirection, normal);
                if (tangent.sqrMagnitude <= Mathf.Epsilon)
                {
                    return false;
                }

                tangent.Normalize();
                startDirection = Quaternion.AngleAxis(-interactable.MaxApproachAngle, normal) * tangent;
                totalAngle = interactable.MaxApproachAngle * 2f;
            }
            else
            {
                var fallback = Vector3.Cross(normal, Vector3.up);
                if (fallback.sqrMagnitude <= Mathf.Epsilon)
                {
                    fallback = Vector3.Cross(normal, Vector3.right);
                }

                if (fallback.sqrMagnitude <= Mathf.Epsilon)
                {
                    return false;
                }

                startDirection = fallback.normalized;
                totalAngle = 360f;
            }

            for (var index = 0; index <= BoxConeArcSegments; index++)
            {
                var t = BoxConeArcSegments == 0 ? 0f : index / (float)BoxConeArcSegments;
                var direction = Quaternion.AngleAxis(totalAngle * t, normal) * startDirection;
                if (TrySolveColliderBoundaryPoint(interactable, referenceTransform, direction, boundaryDistance, out var point))
                {
                    points.Add(point);
                }
            }

            return points.Count >= 2;
        }

        private static bool TrySolveColliderBoundaryPoint(Interactable interactable,
                                                          Transform referenceTransform,
                                                          Vector3 direction,
                                                          float boundaryDistance,
                                                          out Vector3 point)
        {
            point = referenceTransform.position;
            var normalizedDirection = direction.normalized;
            if (normalizedDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            var origin = referenceTransform.position;
            if (boundaryDistance <= 0f)
            {
                var queryPoint = origin + normalizedDirection * GetColliderPreviewSearchRadius(interactable, referenceTransform);
                return TryGetClosestMeasurementPoint(interactable, referenceTransform, queryPoint, out point);
            }

            var low = 0f;
            var high = GetColliderPreviewSearchRadius(interactable, referenceTransform) + boundaryDistance;
            if (!TryMeasureColliderDistanceAtPoint(interactable, referenceTransform, origin + normalizedDirection * high, out var highDistance))
            {
                return false;
            }

            var expandCount = 0;
            while (highDistance < boundaryDistance && expandCount < 8)
            {
                high *= 2f;
                if (!TryMeasureColliderDistanceAtPoint(interactable, referenceTransform, origin + normalizedDirection * high, out highDistance))
                {
                    return false;
                }
                expandCount++;
            }

            if (highDistance < boundaryDistance)
            {
                return false;
            }

            for (var i = 0; i < 18; i++)
            {
                var mid = (low + high) * 0.5f;
                if (!TryMeasureColliderDistanceAtPoint(interactable, referenceTransform, origin + normalizedDirection * mid, out var midDistance))
                {
                    return false;
                }

                if (midDistance < boundaryDistance)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }

            point = origin + normalizedDirection * high;
            return true;
        }

        private static bool TryMeasureColliderDistanceAtPoint(Interactable interactable,
                                                              Transform referenceTransform,
                                                              Vector3 actorPoint,
                                                              out float distance)
        {
            distance = 0f;
            if (!TryGetClosestMeasurementPoint(interactable, referenceTransform, actorPoint, out var targetPoint))
            {
                return false;
            }

            distance = GetPreviewMeasuredDistance(interactable, referenceTransform, actorPoint, targetPoint);
            return true;
        }

        private static bool TryGetClosestMeasurementPoint(Interactable interactable,
                                                          Transform referenceTransform,
                                                          Vector3 actorPoint,
                                                          out Vector3 targetPoint)
        {
            targetPoint = referenceTransform.position;
            var colliders = interactable.GetComponentsInChildren<Collider>(true);
            var found = false;
            var bestDistance = float.PositiveInfinity;
            var referencePosition = referenceTransform.position;
            var queryPoint = ApplyMeasurementAxisToPoint(interactable, referenceTransform, referencePosition, actorPoint);

            for (var i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (!collider || !collider.enabled || !collider.gameObject.activeInHierarchy || !PhysicsColliderQueries.IsSupportedOverlapCollider(collider))
                {
                    continue;
                }

                var candidate = collider.ClosestPoint(queryPoint);
                if ((candidate - queryPoint).sqrMagnitude <= Mathf.Epsilon && PhysicsColliderQueries.TryContainsPoint(collider, queryPoint))
                {
                    if (!PhysicsColliderQueries.TryGetClosestSurfacePoint(collider, queryPoint, out candidate))
                    {
                        candidate = collider.ClosestPointOnBounds(queryPoint);
                    }
                }

                var measuredDistance = GetPreviewMeasuredDistance(interactable, referenceTransform, actorPoint, candidate);
                if (measuredDistance >= bestDistance)
                {
                    continue;
                }

                bestDistance = measuredDistance;
                targetPoint = candidate;
                found = true;
            }

            return found;
        }

        private static Vector3 ApplyMeasurementAxisToPoint(Interactable interactable,
                                                           Transform referenceTransform,
                                                           Vector3 from,
                                                           Vector3 to)
        {
            if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.World)
            {
                return MoveAxisHelper.Apply(interactable.MeasurementAxis, from, to);
            }

            if (!referenceTransform)
            {
                return MoveAxisHelper.Apply(interactable.MeasurementAxis, from, to);
            }

            var localFrom = referenceTransform.InverseTransformPoint(from);
            var localTo = referenceTransform.InverseTransformPoint(to);
            var localApplied = MoveAxisHelper.Apply(interactable.MeasurementAxis, localFrom, localTo);
            return referenceTransform.TransformPoint(localApplied);
        }

        private static float GetColliderPreviewSearchRadius(Interactable interactable, Transform referenceTransform)
        {
            var colliders = interactable.GetComponentsInChildren<Collider>(true);
            var bounds = new Bounds(referenceTransform.position, Vector3.zero);
            var hasBounds = false;
            for (var i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (!collider || !collider.enabled || !collider.gameObject.activeInHierarchy || !PhysicsColliderQueries.IsSupportedOverlapCollider(collider))
                {
                    continue;
                }

                if (!hasBounds)
                {
                    bounds = collider.bounds;
                    hasBounds = true;
                }
                else
                {
                    bounds.Encapsulate(collider.bounds);
                }
            }

            var colliderRadius = hasBounds ? bounds.extents.magnitude : HandleUtility.GetHandleSize(referenceTransform.position);
            return Mathf.Max(colliderRadius, GetConstraintPreviewRadius(interactable, includeBoxConstraints: true));
        }

        private static void DrawBoundaryStripFill(List<Vector3> innerPoints, List<Vector3> outerPoints, Color color, bool closeLoop)
        {
            if (innerPoints == null || outerPoints == null || innerPoints.Count < 2 || outerPoints.Count < 2)
            {
                return;
            }

            var segmentCount = Mathf.Min(innerPoints.Count, outerPoints.Count) - 1;
            if (segmentCount < 1)
            {
                return;
            }

            EnsureConstraintFillResources();
            if (_constraintFillMaterial == null || _constraintFillMesh == null)
            {
                return;
            }

            ConstraintFillVertices.Clear();
            ConstraintFillTriangles.Clear();

            for (var i = 0; i <= segmentCount; i++)
            {
                ConstraintFillVertices.Add(innerPoints[i]);
                ConstraintFillVertices.Add(outerPoints[i]);
            }

            for (var i = 0; i < segmentCount; i++)
            {
                var a = i * 2;
                var b = a + 1;
                var c = a + 2;
                var d = a + 3;

                ConstraintFillTriangles.Add(a);
                ConstraintFillTriangles.Add(b);
                ConstraintFillTriangles.Add(c);
                ConstraintFillTriangles.Add(b);
                ConstraintFillTriangles.Add(d);
                ConstraintFillTriangles.Add(c);
            }

            if (closeLoop)
            {
                var last = segmentCount * 2;
                ConstraintFillTriangles.Add(last);
                ConstraintFillTriangles.Add(last + 1);
                ConstraintFillTriangles.Add(0);
                ConstraintFillTriangles.Add(last + 1);
                ConstraintFillTriangles.Add(1);
                ConstraintFillTriangles.Add(0);
            }

            _constraintFillMesh.Clear();
            _constraintFillMesh.SetVertices(ConstraintFillVertices);
            _constraintFillMesh.SetTriangles(ConstraintFillTriangles, 0);
            _constraintFillMesh.RecalculateBounds();
            _constraintFillMesh.RecalculateNormals();

            _constraintFillMaterial.SetColor("_Color", color);
            _constraintFillMaterial.SetPass(0);
            Graphics.DrawMeshNow(_constraintFillMesh, Matrix4x4.identity);
        }

        private static void AddColliderSphericalPatch(Interactable interactable,
                                                      Transform referenceTransform,
                                                      Vector3 shellForward,
                                                      Vector3 shellRight,
                                                      Vector3 shellUp,
                                                      float boundaryDistance,
                                                      float polarMin,
                                                      float polarMax,
                                                      bool outward)
        {
            var startVertex = ConstraintFillVertices.Count;
            for (var polarIndex = 0; polarIndex <= ConeFillPolarSegments; polarIndex++)
            {
                var polarT = ConeFillPolarSegments == 0 ? 0f : polarIndex / (float)ConeFillPolarSegments;
                var polarAngle = Mathf.Lerp(polarMin, polarMax, polarT) * Mathf.Deg2Rad;
                var sinPolar = Mathf.Sin(polarAngle);
                var cosPolar = Mathf.Cos(polarAngle);

                for (var radialIndex = 0; radialIndex <= ConeFillRadialSegments; radialIndex++)
                {
                    var azimuthT = ConeFillRadialSegments == 0 ? 0f : radialIndex / (float)ConeFillRadialSegments;
                    var azimuth = azimuthT * Mathf.PI * 2f;
                    var ringDirection = shellRight * Mathf.Cos(azimuth) + shellUp * Mathf.Sin(azimuth);
                    var direction = shellForward * cosPolar + ringDirection * sinPolar;

                    if (!TrySolveColliderBoundaryPoint(interactable, referenceTransform, direction, boundaryDistance, out var point))
                    {
                        point = referenceTransform.position;
                    }

                    ConstraintFillVertices.Add(point);
                }
            }

            AddGridTriangles(startVertex,
                             ConeFillPolarSegments + 1,
                             ConeFillRadialSegments + 1,
                             outward);
        }

        private static void AddColliderPolarBoundarySurface(Interactable interactable,
                                                            Transform referenceTransform,
                                                            Vector3 shellForward,
                                                            Vector3 shellRight,
                                                            Vector3 shellUp,
                                                            float polarAngleDegrees,
                                                            float innerDistance,
                                                            float outerDistance)
        {
            var startVertex = ConstraintFillVertices.Count;
            var polarAngle = polarAngleDegrees * Mathf.Deg2Rad;
            var sinPolar = Mathf.Sin(polarAngle);
            var cosPolar = Mathf.Cos(polarAngle);

            for (var distanceIndex = 0; distanceIndex <= 1; distanceIndex++)
            {
                var boundaryDistance = distanceIndex == 0 ? innerDistance : outerDistance;
                for (var radialIndex = 0; radialIndex <= ConeFillRadialSegments; radialIndex++)
                {
                    var azimuthT = ConeFillRadialSegments == 0 ? 0f : radialIndex / (float)ConeFillRadialSegments;
                    var azimuth = azimuthT * Mathf.PI * 2f;
                    var ringDirection = shellRight * Mathf.Cos(azimuth) + shellUp * Mathf.Sin(azimuth);
                    var direction = shellForward * cosPolar + ringDirection * sinPolar;

                    if (!TrySolveColliderBoundaryPoint(interactable, referenceTransform, direction, boundaryDistance, out var point))
                    {
                        point = referenceTransform.position;
                    }

                    ConstraintFillVertices.Add(point);
                }
            }

            AddGridTriangles(startVertex, 2, ConeFillRadialSegments + 1, outward: true);
        }

        private static void DrawBoxConstrainedFill(Vector3 origin,
                                                   (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                   Vector3 extents,
                                                   Vector3 forwardDirection,
                                                   float maxAngle,
                                                   MoveAxis measurementAxis,
                                                   Color color)
        {
            switch (measurementAxis)
            {
                case MoveAxis.XY:
                    if (TryBuildBoxClippedPlanarBoundary(origin, basis, extents, basis.forward, forwardDirection, maxAngle, out var xyPoints))
                    {
                        DrawTriangleFanFill(origin, xyPoints, color, closeLoop: false);
                    }
                    break;
                case MoveAxis.XZ:
                    if (TryBuildBoxClippedPlanarBoundary(origin, basis, extents, basis.up, forwardDirection, maxAngle, out var xzPoints))
                    {
                        DrawTriangleFanFill(origin, xzPoints, color, closeLoop: false);
                    }
                    break;
                case MoveAxis.YZ:
                    if (TryBuildBoxClippedPlanarBoundary(origin, basis, extents, basis.right, forwardDirection, maxAngle, out var yzPoints))
                    {
                        DrawTriangleFanFill(origin, yzPoints, color, closeLoop: false);
                    }
                    break;
                case MoveAxis.XYZ:
                    if (TryBuildBoxClippedConeLoop(origin, basis, extents, forwardDirection, maxAngle, out var coneLoop))
                    {
                        DrawTriangleFanFill(origin, coneLoop, color, closeLoop: true);
                    }
                    break;
            }
        }

        private static void DrawBoxClippedPlanarApproach(Vector3 origin,
                                                         (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                         Vector3 extents,
                                                         Vector3 planeNormal,
                                                         Vector3 forwardDirection,
                                                         float maxAngle)
        {
            if (!TryBuildBoxClippedPlanarBoundary(origin, basis, extents, planeNormal, forwardDirection, maxAngle, out var points))
            {
                return;
            }

            var normal = planeNormal.normalized;
            var tangent = Vector3.ProjectOnPlane(forwardDirection, normal).normalized;
            var startDirection = Quaternion.AngleAxis(-maxAngle, normal) * tangent;
            var endDirection = Quaternion.AngleAxis(maxAngle, normal) * tangent;

            Handles.color = ApproachColor;
            Handles.DrawAAPolyLine(GizmoLineThickness, points.ToArray());

            if (TryGetRayToBoxIntersection(origin, basis, extents, startDirection, out var startPoint))
            {
                Handles.DrawLine(origin, startPoint, GizmoLineThickness);
            }

            if (TryGetRayToBoxIntersection(origin, basis, extents, endDirection, out var endPoint))
            {
                Handles.DrawLine(origin, endPoint, GizmoLineThickness);
            }
        }

        private static void DrawBoxClippedConeApproach(Vector3 origin,
                                                       (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                       Vector3 extents,
                                                       Vector3 forwardDirection,
                                                       float maxAngle)
        {
            if (!TryBuildBoxClippedConeLoop(origin, basis, extents, forwardDirection, maxAngle, out var loopPoints))
            {
                return;
            }

            var normalizedForward = forwardDirection.normalized;
            GetConeFrame(normalizedForward, out var ringRight, out var ringUp);
            var cosAngle = Mathf.Cos(maxAngle * Mathf.Deg2Rad);
            var sinAngle = Mathf.Sin(maxAngle * Mathf.Deg2Rad);

            loopPoints.Add(loopPoints[0]);
            Handles.color = ApproachColor;
            Handles.DrawAAPolyLine(GizmoLineThickness, loopPoints.ToArray());

            var connectorDirections = new[]
            {
                normalizedForward * cosAngle + ringRight * sinAngle,
                normalizedForward * cosAngle - ringRight * sinAngle,
                normalizedForward * cosAngle + ringUp * sinAngle,
                normalizedForward * cosAngle - ringUp * sinAngle
            };

            for (var i = 0; i < connectorDirections.Length; i++)
            {
                if (TryGetRayToBoxIntersection(origin, basis, extents, connectorDirections[i], out var connectorPoint))
                {
                    Handles.DrawLine(origin, connectorPoint, GizmoLineThickness);
                }
            }
        }

        private static bool TryBuildBoxClippedPlanarBoundary(Vector3 origin,
                                                             (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                             Vector3 extents,
                                                             Vector3 planeNormal,
                                                             Vector3 forwardDirection,
                                                             float maxAngle,
                                                             out List<Vector3> points)
        {
            points = new List<Vector3>(BoxConeArcSegments + 1);

            var normal = planeNormal.normalized;
            var tangent = Vector3.ProjectOnPlane(forwardDirection, normal);
            if (normal.sqrMagnitude <= Mathf.Epsilon || tangent.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            tangent.Normalize();
            var startDirection = Quaternion.AngleAxis(-maxAngle, normal) * tangent;
            for (var index = 0; index <= BoxConeArcSegments; index++)
            {
                var t = BoxConeArcSegments == 0 ? 0f : index / (float)BoxConeArcSegments;
                var angle = maxAngle * 2f * t;
                var direction = Quaternion.AngleAxis(angle, normal) * startDirection;
                if (TryGetRayToBoxIntersection(origin, basis, extents, direction, out var point))
                {
                    points.Add(point);
                }
            }

            return points.Count >= 2;
        }

        private static bool TryBuildBoxClippedConeLoop(Vector3 origin,
                                                       (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                       Vector3 extents,
                                                       Vector3 forwardDirection,
                                                       float maxAngle,
                                                       out List<Vector3> loopPoints)
        {
            loopPoints = new List<Vector3>(BoxConeArcSegments + 1);

            var normalizedForward = forwardDirection.normalized;
            if (normalizedForward.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            GetConeFrame(normalizedForward, out var ringRight, out var ringUp);
            var cosAngle = Mathf.Cos(maxAngle * Mathf.Deg2Rad);
            var sinAngle = Mathf.Sin(maxAngle * Mathf.Deg2Rad);

            for (var index = 0; index <= BoxConeArcSegments; index++)
            {
                var t = BoxConeArcSegments == 0 ? 0f : index / (float)BoxConeArcSegments;
                var azimuth = t * Mathf.PI * 2f;
                var ringDirection = ringRight * Mathf.Cos(azimuth) + ringUp * Mathf.Sin(azimuth);
                var direction = normalizedForward * cosAngle + ringDirection * sinAngle;
                if (TryGetRayToBoxIntersection(origin, basis, extents, direction, out var point))
                {
                    loopPoints.Add(point);
                }
            }

            return loopPoints.Count >= 3;
        }

        private static void DrawTriangleFanFill(Vector3 origin, List<Vector3> boundaryPoints, Color color, bool closeLoop)
        {
            if (boundaryPoints == null || boundaryPoints.Count < 2)
            {
                return;
            }

            EnsureConstraintFillResources();
            if (_constraintFillMaterial == null || _constraintFillMesh == null)
            {
                return;
            }

            ConstraintFillVertices.Clear();
            ConstraintFillTriangles.Clear();

            ConstraintFillVertices.Add(origin);
            ConstraintFillVertices.AddRange(boundaryPoints);

            var lastBoundaryIndex = closeLoop ? boundaryPoints.Count : boundaryPoints.Count - 1;
            for (var index = 1; index <= lastBoundaryIndex; index++)
            {
                var next = index == boundaryPoints.Count ? 1 : index + 1;
                ConstraintFillTriangles.Add(0);
                ConstraintFillTriangles.Add(index);
                ConstraintFillTriangles.Add(next);
            }

            _constraintFillMesh.Clear();
            _constraintFillMesh.SetVertices(ConstraintFillVertices);
            _constraintFillMesh.SetTriangles(ConstraintFillTriangles, 0);
            _constraintFillMesh.RecalculateBounds();
            _constraintFillMesh.RecalculateNormals();

            _constraintFillMaterial.SetColor("_Color", color);
            _constraintFillMaterial.SetPass(0);
            Graphics.DrawMeshNow(_constraintFillMesh, Matrix4x4.identity);
        }

        private static bool TryGetFacingPreview(Interactable interactable,
                                                Transform referenceTransform,
                                                out Vector3 previewPoint,
                                                out Vector3 facingDirection)
        {
            previewPoint = referenceTransform.position;
            facingDirection = Vector3.zero;

            if (FacingPreviewOverrides.TryGetValue(interactable.GetTransientId(), out previewPoint))
            {
                var overrideToTarget = referenceTransform.position - previewPoint;
                if (overrideToTarget.sqrMagnitude <= Mathf.Epsilon)
                {
                    return false;
                }

                facingDirection = overrideToTarget.normalized;
                return true;
            }

            var outwardDirection = GetFacingPreviewDirection(interactable, referenceTransform);
            if (outwardDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box && HasBoxConstraint(interactable))
            {
                var basis = GetMeasurementBasis(referenceTransform, interactable);
                var extents = GetBoxConstraintExtentsForGizmo(interactable, referenceTransform.position);
                if (!TryGetRayToBoxIntersection(referenceTransform.position, basis, extents, outwardDirection, out previewPoint))
                {
                    return false;
                }

                var boxInset = Mathf.Max(GetFacingPreviewRadius(interactable, previewPoint) * 0.75f,
                                         HandleUtility.GetHandleSize(previewPoint) * 0.15f);
                previewPoint -= outwardDirection.normalized * boxInset;
            }
            else
            {
                if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider &&
                    interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Radial &&
                    interactable.MaxInteractionDistance > 0f &&
                    TrySolveColliderBoundaryPoint(interactable,
                                                  referenceTransform,
                                                  outwardDirection,
                                                  interactable.MaxInteractionDistance,
                                                  out previewPoint))
                {
                    var insetOffset = outwardDirection.normalized * Mathf.Max(GetFacingPreviewRadius(interactable, previewPoint) * 0.75f, 0.05f);
                    previewPoint -= insetOffset;
                }
                else
                {
                    var distance = interactable.MaxInteractionDistance > 0f
                        ? interactable.MaxInteractionDistance
                        : GetConstraintPreviewRadius(interactable, includeBoxConstraints: true);
                    if (distance <= 0f)
                    {
                        return false;
                    }

                    var insetDistance = Mathf.Min(distance * 0.8f, distance - Mathf.Max(distance * 0.1f, 0.05f));
                    if (insetDistance <= 0f)
                    {
                        insetDistance = distance * 0.5f;
                    }

                    previewPoint = referenceTransform.position + outwardDirection * insetDistance;
                }
            }

            var toTarget = referenceTransform.position - previewPoint;
            if (toTarget.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            facingDirection = toTarget.normalized;
            return true;
        }

        private static Vector3 GetFacingPreviewDirection(Interactable interactable, Transform referenceTransform)
        {
            var projectedApproach = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);
            if (projectedApproach.sqrMagnitude > Mathf.Epsilon)
            {
                return projectedApproach.normalized;
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);
            return interactable.MeasurementAxis switch
            {
                MoveAxis.XY => basis.right.sqrMagnitude > Mathf.Epsilon ? basis.right.normalized : Vector3.right,
                MoveAxis.XZ => basis.forward.sqrMagnitude > Mathf.Epsilon ? basis.forward.normalized : Vector3.forward,
                MoveAxis.YZ => basis.up.sqrMagnitude > Mathf.Epsilon ? basis.up.normalized : Vector3.up,
                MoveAxis.X => basis.right.sqrMagnitude > Mathf.Epsilon ? basis.right.normalized : Vector3.right,
                MoveAxis.Y => basis.up.sqrMagnitude > Mathf.Epsilon ? basis.up.normalized : Vector3.up,
                _ => basis.forward.sqrMagnitude > Mathf.Epsilon ? basis.forward.normalized : referenceTransform.forward
            };
        }

        private static bool TryGetFacingArcNormal(Interactable interactable,
                                                  Transform referenceTransform,
                                                  Vector3 facingDirection,
                                                  out Vector3 arcNormal)
        {
            if (TryGetMeasurementArcNormal(interactable, referenceTransform, out arcNormal))
            {
                return true;
            }

            var sceneView = SceneView.currentDrawingSceneView;
            if (sceneView != null && sceneView.camera != null)
            {
                var candidate = Vector3.Cross(facingDirection, sceneView.camera.transform.forward);
                if (candidate.sqrMagnitude > Mathf.Epsilon)
                {
                    arcNormal = candidate.normalized;
                    return true;
                }
            }

            var basis = GetMeasurementBasis(referenceTransform, interactable);
            var fallback = Vector3.Cross(facingDirection, basis.up);
            if (fallback.sqrMagnitude <= Mathf.Epsilon)
            {
                fallback = Vector3.Cross(facingDirection, basis.right);
            }

            if (fallback.sqrMagnitude <= Mathf.Epsilon)
            {
                arcNormal = Vector3.zero;
                return false;
            }

            arcNormal = fallback.normalized;
            return true;
        }

        private static float GetFacingPreviewRadius(Interactable interactable, Vector3 previewPoint)
        {
            var constraintRadius = GetConstraintPreviewRadius(interactable, includeBoxConstraints: true);
            var handleRadius = HandleUtility.GetHandleSize(previewPoint) * 0.85f;
            if (constraintRadius <= 0f)
            {
                return handleRadius;
            }

            return Mathf.Clamp(constraintRadius * 0.3f, handleRadius * 0.75f, handleRadius * 2f);
        }

        private static bool IsFacingPreviewPositionValid(Interactable interactable,
                                                         Transform referenceTransform,
                                                         Vector3 previewPoint)
        {
            var targetPoint = referenceTransform.position;
            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider)
            {
                TryGetClosestMeasurementPoint(interactable, referenceTransform, previewPoint, out targetPoint);
            }

            if (!IsWithinPreviewPositionConstraint(interactable, referenceTransform, previewPoint, targetPoint))
            {
                return false;
            }

            if (!interactable.RequireApproach)
            {
                return true;
            }

            var normal = ProjectForMeasurement(interactable, referenceTransform, interactable.ApproachNormal);
            if (normal.sqrMagnitude <= Mathf.Epsilon)
            {
                normal = ProjectForMeasurement(interactable, referenceTransform, interactable.GetDirectionAxisWorldVector());
            }

            if (normal.sqrMagnitude <= Mathf.Epsilon)
            {
                normal = ProjectForMeasurement(interactable, referenceTransform, Vector3.forward);
            }

            if (normal.sqrMagnitude <= Mathf.Epsilon)
            {
                return true;
            }

            var standDirection = ProjectForMeasurement(interactable, referenceTransform, previewPoint - targetPoint);
            if (standDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return false;
            }

            return Vector3.Angle(standDirection, normal) <= interactable.MaxApproachAngle;
        }

        private static bool IsWithinPreviewPositionConstraint(Interactable interactable,
                                                              Transform referenceTransform,
                                                              Vector3 from,
                                                              Vector3 to)
        {
            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box)
            {
                var offset = to - from;
                if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.ReferenceTransform)
                {
                    offset = referenceTransform.InverseTransformDirection(offset);
                }

                var maxPositionDelta = interactable.MaxPositionDelta;
                var absOffset = new Vector3(Mathf.Abs(offset.x), Mathf.Abs(offset.y), Mathf.Abs(offset.z));
                if (maxPositionDelta.x > 0f && absOffset.x > maxPositionDelta.x) return false;
                if (maxPositionDelta.y > 0f && absOffset.y > maxPositionDelta.y) return false;
                if (maxPositionDelta.z > 0f && absOffset.z > maxPositionDelta.z) return false;
                return true;
            }

            var distance = GetPreviewMeasuredDistance(interactable, referenceTransform, from, to);
            if (interactable.MinInteractionDistance > 0f && distance < interactable.MinInteractionDistance)
            {
                return false;
            }

            return interactable.MaxInteractionDistance <= 0f || distance <= interactable.MaxInteractionDistance;
        }

        private static float GetPreviewMeasuredDistance(Interactable interactable,
                                                        Transform referenceTransform,
                                                        Vector3 from,
                                                        Vector3 to)
        {
            Vector3 projected;

            if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.ReferenceTransform)
            {
                var localDirection = referenceTransform.InverseTransformDirection(to - from);
                projected = MoveAxisHelper.ProjectToAxis(interactable.MeasurementAxis, localDirection);
            }
            else
            {
                projected = MoveAxisHelper.ProjectToAxis(interactable.MeasurementAxis, to - from);
            }

            return projected.magnitude;
        }

        private static bool TryGetRayToBoxIntersection(Vector3 origin,
                                                       (Vector3 right, Vector3 up, Vector3 forward) basis,
                                                       Vector3 extents,
                                                       Vector3 direction,
                                                       out Vector3 point)
        {
            point = origin;

            var localDirection = new Vector3(
                Vector3.Dot(direction, basis.right),
                Vector3.Dot(direction, basis.up),
                Vector3.Dot(direction, basis.forward));

            if (!TryGetRayDistanceToExtents(localDirection, extents, out var distance))
            {
                return false;
            }

            point = origin + direction.normalized * distance;
            return true;
        }

        private static bool TryGetRayDistanceToExtents(Vector3 localDirection, Vector3 extents, out float distance)
        {
            distance = float.PositiveInfinity;
            var found = false;

            if (Mathf.Abs(localDirection.x) > Mathf.Epsilon)
            {
                distance = Mathf.Min(distance, extents.x / Mathf.Abs(localDirection.x));
                found = true;
            }

            if (Mathf.Abs(localDirection.y) > Mathf.Epsilon)
            {
                distance = Mathf.Min(distance, extents.y / Mathf.Abs(localDirection.y));
                found = true;
            }

            if (Mathf.Abs(localDirection.z) > Mathf.Epsilon)
            {
                distance = Mathf.Min(distance, extents.z / Mathf.Abs(localDirection.z));
                found = true;
            }

            return found && distance > 0f && !float.IsInfinity(distance);
        }

        private static void DrawBoxDistanceConstraint(Interactable interactable, Transform referenceTransform)
        {
            if (!HasBoxConstraint(interactable))
            {
                return;
            }

            var (_, up, forward) = GetMeasurementBasis(referenceTransform, interactable);
            var extents = GetBoxConstraintExtentsForGizmo(interactable, referenceTransform.position);
            var matrix = Matrix4x4.TRS(referenceTransform.position, Quaternion.LookRotation(forward, up), Vector3.one);

            using (new Handles.DrawingScope(matrix))
            {
                Handles.color = interactable.RequireApproach ? BoxDistanceMutedColor : BoxDistanceColor;
                Handles.DrawWireCube(Vector3.zero, extents * 2f);
            }
        }

        private static float GetConstraintPreviewRadius(Interactable interactable, bool includeBoxConstraints)
        {
            if (includeBoxConstraints && HasBoxConstraint(interactable))
            {
                var maxPositionDelta = interactable.MaxPositionDelta;
                var extent = Mathf.Max(maxPositionDelta.x, Mathf.Max(maxPositionDelta.y, maxPositionDelta.z));
                if (extent > 0f)
                {
                    return extent;
                }
            }

            if (interactable.MaxInteractionDistance > 0f)
            {
                return interactable.MaxInteractionDistance;
            }

            return HandleUtility.GetHandleSize(interactable.ReferenceTransform.position) * 1.5f;
        }

        private static bool HasBoxConstraint(Interactable interactable)
        {
            if (!interactable || interactable.PositionDistanceMode != Interactable.PositionConstraintMode.Box)
            {
                return false;
            }

            var maxPositionDelta = interactable.MaxPositionDelta;
            return maxPositionDelta.x > 0f || maxPositionDelta.y > 0f || maxPositionDelta.z > 0f;
        }

        private static Vector3 GetBoxConstraintExtentsForGizmo(Interactable interactable, Vector3 position)
        {
            var maxPositionDelta = interactable.MaxPositionDelta;
            var minVisibleThickness = Mathf.Max(HandleUtility.GetHandleSize(position) * 0.03f, 0.02f);
            return new Vector3(
                maxPositionDelta.x > 0f ? maxPositionDelta.x : minVisibleThickness,
                maxPositionDelta.y > 0f ? maxPositionDelta.y : minVisibleThickness,
                maxPositionDelta.z > 0f ? maxPositionDelta.z : minVisibleThickness);
        }

        private static Vector3 ProjectForMeasurement(Interactable interactable, Transform referenceTransform, Vector3 direction)
        {
            Vector3 vector;

            if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.ReferenceTransform)
            {
                var localDirection = referenceTransform.InverseTransformDirection(direction);
                var localProjected = MoveAxisHelper.ProjectToAxis(interactable.MeasurementAxis, localDirection);
                vector = referenceTransform.TransformDirection(localProjected);
            }
            else
            {
                vector = MoveAxisHelper.ProjectToAxis(interactable.MeasurementAxis, direction);
            }

            return vector.sqrMagnitude <= Mathf.Epsilon ? Vector3.zero : vector.normalized;
        }

        private static bool TryGetMeasurementArcNormal(Interactable interactable, Transform referenceTransform, out Vector3 normal)
        {
            var basis = GetMeasurementBasis(referenceTransform, interactable);
            switch (interactable.MeasurementAxis)
            {
                case MoveAxis.XY:
                    normal = basis.forward;
                    return true;
                case MoveAxis.XZ:
                    normal = basis.up;
                    return true;
                case MoveAxis.YZ:
                    normal = basis.right;
                    return true;
                default:
                    normal = Vector3.zero;
                    return false;
            }
        }

        private static void DrawAngularFan(Vector3 origin,
                                           Vector3 forwardDirection,
                                           Vector3 arcNormal,
                                           float maxAngle,
                                           float minRadius,
                                           float maxRadius,
                                           Color outlineColor)
        {
            if (maxRadius <= 0f)
            {
                return;
            }

            var startDirection = Quaternion.AngleAxis(-maxAngle, arcNormal) * forwardDirection;
            var endDirection = Quaternion.AngleAxis(maxAngle, arcNormal) * forwardDirection;

            Handles.color = outlineColor;
            Handles.DrawWireArc(origin, arcNormal, startDirection, maxAngle * 2f, maxRadius);
            if (minRadius > 0f)
            {
                Handles.DrawWireArc(origin, arcNormal, startDirection, maxAngle * 2f, minRadius);
                Handles.DrawLine(origin + startDirection * minRadius, origin + startDirection * maxRadius, GizmoLineThickness);
                Handles.DrawLine(origin + endDirection * minRadius, origin + endDirection * maxRadius, GizmoLineThickness);
                return;
            }

            Handles.DrawLine(origin, origin + startDirection * maxRadius, GizmoLineThickness);
            Handles.DrawLine(origin, origin + endDirection * maxRadius, GizmoLineThickness);
        }

        private static void DrawConeFrustum(Vector3 origin,
                                            Vector3 forwardDirection,
                                            float maxAngle,
                                            float minRadius,
                                            float maxRadius,
                                            Color outlineColor)
        {
            if (forwardDirection.sqrMagnitude <= Mathf.Epsilon || maxRadius <= 0f)
            {
                return;
            }

            var normalizedForward = forwardDirection.normalized;
            GetConeFrame(normalizedForward, out var right, out var up);

            DrawConeCircle(origin, normalizedForward, maxAngle, maxRadius, outlineColor);

            if (minRadius > 0f)
            {
                DrawConeCircle(origin, normalizedForward, maxAngle, minRadius, outlineColor);
                DrawConeFrustumEdges(origin, normalizedForward, right, up, maxAngle, minRadius, maxRadius, outlineColor);
                return;
            }

            DrawConeFrustumEdges(origin, normalizedForward, right, up, maxAngle, 0f, maxRadius, outlineColor);
        }

        private static void DrawConeCircle(Vector3 origin,
                                           Vector3 normalizedForward,
                                           float maxAngle,
                                           float radius,
                                           Color outlineColor)
        {
            var angleRadians = maxAngle * Mathf.Deg2Rad;
            var circleCenter = origin + normalizedForward * (Mathf.Cos(angleRadians) * radius);
            var circleRadius = Mathf.Sin(angleRadians) * radius;
            if (circleRadius <= Mathf.Epsilon)
            {
                return;
            }

            Handles.color = outlineColor;
            Handles.DrawWireDisc(circleCenter, normalizedForward, circleRadius);
        }

        private static void DrawConeFrustumEdges(Vector3 origin,
                                                 Vector3 normalizedForward,
                                                 Vector3 right,
                                                 Vector3 up,
                                                 float maxAngle,
                                                 float minRadius,
                                                 float maxRadius,
                                                 Color outlineColor)
        {
            var angleRadians = maxAngle * Mathf.Deg2Rad;
            var nearCenter = origin + normalizedForward * (Mathf.Cos(angleRadians) * minRadius);
            var farCenter = origin + normalizedForward * (Mathf.Cos(angleRadians) * maxRadius);
            var nearCircleRadius = Mathf.Sin(angleRadians) * minRadius;
            var farCircleRadius = Mathf.Sin(angleRadians) * maxRadius;

            Handles.color = outlineColor;
            DrawFrustumEdgeSegment(origin, nearCenter, farCenter, right, nearCircleRadius, farCircleRadius, minRadius);
            DrawFrustumEdgeSegment(origin, nearCenter, farCenter, -right, nearCircleRadius, farCircleRadius, minRadius);
            DrawFrustumEdgeSegment(origin, nearCenter, farCenter, up, nearCircleRadius, farCircleRadius, minRadius);
            DrawFrustumEdgeSegment(origin, nearCenter, farCenter, -up, nearCircleRadius, farCircleRadius, minRadius);
        }

        private static void DrawFrustumEdgeSegment(Vector3 origin,
                                                   Vector3 nearCenter,
                                                   Vector3 farCenter,
                                                   Vector3 direction,
                                                   float nearRadius,
                                                   float farRadius,
                                                   float minRadius)
        {
            var farPoint = farCenter + direction * farRadius;
            if (minRadius > 0f)
            {
                var nearPoint = nearCenter + direction * nearRadius;
                Handles.DrawLine(nearPoint, farPoint, GizmoLineThickness);
                return;
            }

            Handles.DrawLine(origin, farPoint, GizmoLineThickness);
        }

        private static void GetConeFrame(Vector3 forwardDirection, out Vector3 right, out Vector3 up)
        {
            var referenceUp = Mathf.Abs(Vector3.Dot(forwardDirection, Vector3.up)) < 0.98f ? Vector3.up : Vector3.right;
            right = Vector3.Cross(referenceUp, forwardDirection);
            if (right.sqrMagnitude <= Mathf.Epsilon)
            {
                referenceUp = Vector3.forward;
                right = Vector3.Cross(referenceUp, forwardDirection);
            }

            right = right.sqrMagnitude > Mathf.Epsilon ? right.normalized : Vector3.right;
            up = Vector3.Cross(forwardDirection, right);
            up = up.sqrMagnitude > Mathf.Epsilon ? up.normalized : Vector3.up;
        }

        private static Vector3 GetSingleAxisDirectionFromBasis(MoveAxis measurementAxis,
                                                               (Vector3 right, Vector3 up, Vector3 forward) basis)
        {
            return measurementAxis switch
            {
                MoveAxis.X => basis.right,
                MoveAxis.Y => basis.up,
                MoveAxis.Z => basis.forward,
                _ => basis.forward
            };
        }

        private static Vector3 GetSingleAxisDirection(Transform referenceTransform, Interactable interactable)
        {
            var basis = GetMeasurementBasis(referenceTransform, interactable);
            return interactable.MeasurementAxis switch
            {
                MoveAxis.X => basis.right,
                MoveAxis.Y => basis.up,
                MoveAxis.Z => basis.forward,
                _ => basis.forward
            };
        }

        private static bool IsSingleAxisMeasurement(Interactable interactable)
        {
            return interactable.MeasurementAxis is MoveAxis.X or MoveAxis.Y or MoveAxis.Z;
        }

        private static bool IsSingleAxisMeasurementMode(SerializedProperty measurementAxisProperty)
        {
            if (measurementAxisProperty == null || measurementAxisProperty.hasMultipleDifferentValues)
            {
                return false;
            }

            var measurementAxis = (MoveAxis)measurementAxisProperty.enumValueIndex;
            return measurementAxis is MoveAxis.X or MoveAxis.Y or MoveAxis.Z;
        }

        private static void DrawSingleAxisApproachStrip(Interactable interactable, Transform referenceTransform, Vector3 forwardDirection, float radius)
        {
            var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
            if (axisDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var directionSign = Mathf.Sign(Vector3.Dot(forwardDirection, axisDirection));
            if (Mathf.Approximately(directionSign, 0f))
            {
                directionSign = 1f;
            }

            var startDistance = Mathf.Min(0f, directionSign * radius);
            var endDistance = Mathf.Max(0f, directionSign * radius);
            var widthDirection = GetSingleAxisWidthDirection(referenceTransform.position, axisDirection, referenceTransform, interactable);
            var halfWidth = GetSingleAxisStripHalfWidth(interactable, axisDirection, widthDirection, referenceTransform.position);

            DrawStrip(referenceTransform.position,
                      axisDirection,
                      widthDirection,
                      startDistance,
                      endDistance,
                      halfWidth,
                      ApproachFillColor,
                      ApproachColor);
        }


        private static void DrawSingleAxisCenteredStrip(Interactable interactable,
                                                        Transform referenceTransform,
                                                        float radius,
                                                        Color fillColor,
                                                        Color outlineColor)
        {
            var axisDirection = GetSingleAxisDirection(referenceTransform, interactable).normalized;
            if (axisDirection.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            var widthDirection = GetSingleAxisWidthDirection(referenceTransform.position, axisDirection, referenceTransform, interactable);
            var halfWidth = GetSingleAxisStripHalfWidth(interactable, axisDirection, widthDirection, referenceTransform.position);

            DrawStrip(referenceTransform.position,
                      axisDirection,
                      widthDirection,
                      -radius,
                      radius,
                      halfWidth,
                      fillColor,
                      outlineColor);
        }

        private static float GetSingleAxisStripHalfWidth(Interactable interactable,
                                                         Vector3 axisDirection,
                                                         Vector3 widthDirection,
                                                         Vector3 position)
        {
            var minHalfWidth = Mathf.Max(HandleUtility.GetHandleSize(position) * SingleAxisStripWidthScale, 0.05f);
            if (!TryGetSingleAxisBoundsHalfWidth(interactable, axisDirection, widthDirection, out var boundsHalfWidth))
            {
                return minHalfWidth;
            }

            return Mathf.Max(minHalfWidth, boundsHalfWidth);
        }

        private static bool TryGetSingleAxisBoundsHalfWidth(Interactable interactable,
                                                            Vector3 axisDirection,
                                                            Vector3 widthDirection,
                                                            out float halfWidth)
        {
            halfWidth = 0f;
            if (interactable == null)
            {
                return false;
            }

            if (TryGetColliderBounds(interactable.TargetGameObject, out var bounds) ||
                TryGetColliderBounds(interactable.gameObject, out bounds))
            {
                halfWidth = GetBoundsProjectedExtent(bounds, axisDirection, widthDirection);
                return halfWidth > Mathf.Epsilon;
            }

            return false;
        }

        private static bool TryGetColliderBounds(GameObject target, out Bounds bounds)
        {
            bounds = default;
            if (!target)
            {
                return false;
            }

            var colliders = target.GetComponentsInChildren<Collider>(true);
            var hasBounds = false;
            for (var i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (!collider || collider.bounds.size.sqrMagnitude <= Mathf.Epsilon)
                {
                    continue;
                }

                if (!hasBounds)
                {
                    bounds = collider.bounds;
                    hasBounds = true;
                }
                else
                {
                    bounds.Encapsulate(collider.bounds);
                }
            }

            return hasBounds;
        }

        private static float GetBoundsProjectedExtent(Bounds bounds, Vector3 axisDirection, Vector3 widthDirection)
        {
            var extents = bounds.extents;
            var projectedWidth =
                Mathf.Abs(Vector3.Dot(Vector3.right * extents.x, widthDirection)) +
                Mathf.Abs(Vector3.Dot(Vector3.up * extents.y, widthDirection)) +
                Mathf.Abs(Vector3.Dot(Vector3.forward * extents.z, widthDirection));

            if (projectedWidth > Mathf.Epsilon)
            {
                return projectedWidth;
            }

            var fallbackWidth =
                Mathf.Abs(Vector3.Dot(Vector3.right * extents.x, Vector3.Cross(axisDirection, widthDirection).normalized)) +
                Mathf.Abs(Vector3.Dot(Vector3.up * extents.y, Vector3.Cross(axisDirection, widthDirection).normalized)) +
                Mathf.Abs(Vector3.Dot(Vector3.forward * extents.z, Vector3.Cross(axisDirection, widthDirection).normalized));

            return fallbackWidth > Mathf.Epsilon ? fallbackWidth : 0f;
        }

        private static Vector3 GetSingleAxisWidthDirection(Vector3 origin,
                                                           Vector3 axisDirection,
                                                           Transform referenceTransform,
                                                           Interactable interactable)
        {
            var basis = GetMeasurementBasis(referenceTransform, interactable);
            var fallback = Vector3.Cross(axisDirection, basis.up);
            if (fallback.sqrMagnitude > Mathf.Epsilon)
            {
                return fallback.normalized;
            }

            fallback = Vector3.Cross(axisDirection, basis.right);
            if (fallback.sqrMagnitude > Mathf.Epsilon)
            {
                return fallback.normalized;
            }

            fallback = Vector3.Cross(axisDirection, Vector3.up);
            if (fallback.sqrMagnitude > Mathf.Epsilon)
            {
                return fallback.normalized;
            }

            var sceneView = SceneView.currentDrawingSceneView;
            if (sceneView != null && sceneView.camera != null)
            {
                var cameraForward = sceneView.camera.transform.forward;
                var widthDirection = Vector3.Cross(axisDirection, cameraForward);
                if (widthDirection.sqrMagnitude > Mathf.Epsilon)
                {
                    return widthDirection.normalized;
                }
            }

            return Vector3.right;
        }

        private static void DrawStrip(Vector3 origin,
                                      Vector3 axisDirection,
                                      Vector3 widthDirection,
                                      float startDistance,
                                      float endDistance,
                                      float halfWidth,
                                      Color fillColor,
                                      Color outlineColor)
        {
            var start = origin + axisDirection * startDistance;
            var end = origin + axisDirection * endDistance;
            var offset = widthDirection * halfWidth;
            var vertices = new[]
            {
                start - offset,
                start + offset,
                end + offset,
                end - offset
            };

            Handles.color = fillColor;
            Handles.DrawAAConvexPolygon(vertices);

            Handles.color = outlineColor;
            Handles.DrawPolyLine(vertices[0], vertices[1], vertices[2], vertices[3], vertices[0]);
            Handles.DrawLine(origin - offset, origin + offset, GizmoLineThickness);
        }

        private static (Vector3 right, Vector3 up, Vector3 forward) GetMeasurementBasis(Transform referenceTransform, Interactable interactable)
        {
            if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.ReferenceTransform)
            {
                return (referenceTransform.right, referenceTransform.up, referenceTransform.forward);
            }

            return (Vector3.right, Vector3.up, Vector3.forward);
        }

    }
}
