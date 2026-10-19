using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
using System.Text;
#endif

namespace HutongGames.PlayMaker
{
    [AddComponentMenu("PlayMaker/Interactor")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/interactables/")]
    [Icon("Packages/com.hutonggames.playmaker/Editor/Resources/playmakerIconSmall.png")]
    [MovedFrom(true, null, null, "InteractionController")]
    public sealed class Interactor : MonoBehaviour
    {
#if UNITY_EDITOR
        public readonly struct DebugCandidateInfo
        {
            public DebugCandidateInfo(Interactable interactable,
                                      float distance,
                                      float rawDistance,
                                      float localMaxDistance,
                                      float approach,
                                      float approachAngle,
                                      float maxApproachAngle,
                                      float facing,
                                      float facingAngle,
                                      float maxFacingAngle,
                                      string result)
            {
                Interactable = interactable;
                Distance = distance;
                RawDistance = rawDistance;
                LocalMaxDistance = localMaxDistance;
                Approach = approach;
                ApproachAngle = approachAngle;
                MaxApproachAngle = maxApproachAngle;
                Facing = facing;
                FacingAngle = facingAngle;
                MaxFacingAngle = maxFacingAngle;
                Result = result;
            }

            public Interactable Interactable { get; }
            public float Distance { get; }
            public float RawDistance { get; }
            public float LocalMaxDistance { get; }
            public float Approach { get; }
            public float ApproachAngle { get; }
            public float MaxApproachAngle { get; }
            public float Facing { get; }
            public float FacingAngle { get; }
            public float MaxFacingAngle { get; }
            public string Result { get; }
        }
#endif

        private readonly struct PassiveCandidateInfo
        {
            public PassiveCandidateInfo(float distance, float approach, float facing)
            {
                Distance = distance;
                Approach = approach;
                Facing = facing;
            }

            public float Distance { get; }
            public float Approach { get; }
            public float Facing { get; }
        }

        private readonly struct PendingInteractSystemEvent
        {
            public PendingInteractSystemEvent(Transform actorTransform,
                                             Interactable interactable,
                                             float distance,
                                             Func<Transform, Interactable, GameObject, Transform, string, string, Vector3, float, InteractSystemEventBase> eventFactory)
            {
                ActorTransform = actorTransform;
                Interactable = interactable;
                Distance = distance;
                EventFactory = eventFactory;
            }

            public Transform ActorTransform { get; }
            public Interactable Interactable { get; }
            public float Distance { get; }
            public Func<Transform, Interactable, GameObject, Transform, string, string, Vector3, float, InteractSystemEventBase> EventFactory { get; }
        }

        private readonly Collider[] _overlapHits = new Collider[32];
        private readonly RaycastHit[] _raycastHits = new RaycastHit[32];
        private readonly List<Interactable> _resolvedHitInteractables = new(4);
        private readonly Dictionary<Interactable, Collider> _candidateColliders = new();
        private readonly Dictionary<Interactable, float> _candidateColliderDistances = new();
        private readonly Dictionary<Interactable, PassiveCandidateInfo> _currentPassiveCandidates = new();
        private readonly Dictionary<Interactable, float> _previousValidInteractables = new();
        private readonly Dictionary<Interactable, float> _currentValidInteractables = new();
        private readonly Dictionary<Interactable, float> _suppressedInteractables = new();
        private readonly HashSet<Interactable> _raycastInteractables = new();
        private readonly List<PendingInteractSystemEvent> _pendingSystemEvents = new(8);
        private Interactable _previousHoverInteractable;
        private float _previousHoverDistance;
        private Interactable _previousActivatedInteractable;
        private Interactable _currentLockedInteractable;
        private float _currentLockedDistance;
        private bool _wasLockActiveInteraction;
        private bool _deferSystemEvents;
        private int _lastPassiveUpdateFrame = -1;
        private bool _passiveStateDirty = true;
        private int _debugHitCount;
#if UNITY_EDITOR
        private bool _debugRaycastRequired;
        private bool _debugRaycastHit;
#endif
        private int _debugResolvedInteractables;
        private int _debugRejectedByTag;
        private int _debugRejectedByUse;
        private int _debugRejectedByDistance;
        private int _debugRejectedByInsideTrigger;
        private int _debugRejectedByApproach;
        private int _debugRejectedByFacing;
        private int _debugRejectedByRaycast;
        private int _debugValidCandidates;
        private string _debugBestTargetName = string.Empty;
        private string _debugBestType = string.Empty;
        private float _debugBestDistance;
        private float _debugBestApproach;
        private float _debugBestFacing;
        private bool _debugHasActivationAttempt;
        private bool _debugLastInteractPressed;
        private string _debugLastInputActivationId = string.Empty;
#if UNITY_EDITOR
        private readonly StringBuilder _debugCandidates = new(256);
        private readonly List<DebugCandidateInfo> _debugCandidateInfos = new(16);
#endif

        [Tooltip("Optional interaction origin transform. Uses this GameObject transform when not assigned.")]
        [SerializeField]
        private Transform _referenceTransform;

        [Tooltip("Layers that may contain Interactable colliders.")]
        [SerializeField]
        private LayerMask _interactableLayers = Physics.DefaultRaycastLayers;

        [Tooltip("Layers that can block the Require Raycast Hit check.")]
        [SerializeField]
        private LayerMask _blockingLayers = Physics.DefaultRaycastLayers;

        [Tooltip("Whether overlap checks should consider Trigger colliders.")]
        [SerializeField]
        private QueryTriggerInteraction _hitTriggers = QueryTriggerInteraction.Collide;

        [Tooltip("Optional tag filter applied to the resolved target GameObject.")]
        [SerializeField]
        private string _requiredTag;

        [Tooltip("Search radius around the interaction origin.")]
        [SerializeField]
        private float _searchRadius = 1.5f;

        [Tooltip("Keeps the current active interaction selected while true, even if temporary gating like facing, approach, raycast, or explicit input is no longer satisfied. The lock is released if the interactable is disabled, destroyed, out of range, or no longer passes the tag filter.")]
        [SerializeField]
        private bool _lockActiveInteraction;

        public Transform ReferenceTransform
        {
            get => _referenceTransform;
            set => SetField(ref _referenceTransform, value);
        }

        public LayerMask InteractableLayers
        {
            get => _interactableLayers;
            set => SetField(ref _interactableLayers, value);
        }

        public LayerMask BlockingLayers
        {
            get => _blockingLayers;
            set => SetField(ref _blockingLayers, value);
        }

        public QueryTriggerInteraction HitTriggers
        {
            get => _hitTriggers;
            set => SetField(ref _hitTriggers, value);
        }

        public string RequiredTag
        {
            get => _requiredTag;
            set => SetField(ref _requiredTag, value);
        }

        public float SearchRadius
        {
            get => _searchRadius;
            set => SetField(ref _searchRadius, value);
        }

        public bool LockActiveInteraction
        {
            get => _lockActiveInteraction;
            set => SetField(ref _lockActiveInteraction, value);
        }

        public bool CanInteract { get; private set; }
        public bool DidActivateThisUpdate { get; private set; }
        public Interactable CurrentHoverInteractable { get; private set; }
        public GameObject CurrentHoverTarget { get; private set; }
        public float CurrentHoverDistance { get; private set; }
        public Interactable CurrentSelectionInteractable { get; private set; }
        public GameObject CurrentSelectionTarget { get; private set; }
        public float CurrentSelectionDistance { get; private set; }
        public string CurrentInteraction { get; private set; } = string.Empty;
        public string CurrentActivationId { get; private set; } = string.Empty;
        public Vector3 CurrentNormal { get; private set; }
        public Interactable CurrentActiveInteractable => _previousActivatedInteractable;

        public void BeginDeferredSystemEvents()
        {
            _deferSystemEvents = true;
        }

        public void FlushPendingSystemEvents()
        {
            _deferSystemEvents = false;
            for (var i = 0; i < _pendingSystemEvents.Count; i++)
            {
                var pendingEvent = _pendingSystemEvents[i];
                DispatchInteractSystemEventNow(pendingEvent.ActorTransform,
                                               pendingEvent.Interactable,
                                               pendingEvent.Distance,
                                               pendingEvent.EventFactory);
            }

            _pendingSystemEvents.Clear();
        }

        public void EnsurePassiveStateUpdated()
        {
            if (!_passiveStateDirty && _lastPassiveUpdateFrame == Time.frameCount)
            {
                return;
            }

            ResetDebugInfo();
            DidActivateThisUpdate = false;

            _currentValidInteractables.Clear();
            _currentPassiveCandidates.Clear();
            _currentLockedInteractable = null;
            _currentLockedDistance = 0f;
            RemoveExpiredSuppressedInteractables();

            if (_wasLockActiveInteraction && !_lockActiveInteraction)
            {
                ClearActiveInteraction();
            }

            _wasLockActiveInteraction = _lockActiveInteraction;

            var originTransform = _referenceTransform != null
                ? _referenceTransform
                : transform;
            if (!originTransform)
            {
                UpdateValidTargets(originTransform);
                ClearHoverTarget(null);
                ClearActiveInteraction();
                ClearOutputs();
                _lastPassiveUpdateFrame = Time.frameCount;
                _passiveStateDirty = false;
                return;
            }

            var actorRootTransform = transform;
            var origin = originTransform.position;
            var radius = Mathf.Max(0f, _searchRadius);
            if (radius <= Mathf.Epsilon)
            {
                UpdateValidTargets(originTransform);
                ClearHoverTarget(originTransform);
                ClearActiveInteraction();
                ClearOutputs();
                _lastPassiveUpdateFrame = Time.frameCount;
                _passiveStateDirty = false;
                return;
            }

            var hitCount = Physics.OverlapSphereNonAlloc(origin,
                                                         radius,
                                                         _overlapHits,
                                                         _interactableLayers,
                                                         _hitTriggers);
            var actorColliders = actorRootTransform.GetComponentsInChildren<Collider>(true);
            _debugHitCount = hitCount;
            var raycastResolved = false;
            _candidateColliders.Clear();
            _candidateColliderDistances.Clear();
            
            Interactable bestHoverInteractable = null;
            var bestHoverDistance = float.PositiveInfinity;
            var bestHoverApproach = -1f;

            for (var i = 0; i < hitCount; ++i)
            {
                var hit = _overlapHits[i];
                if (!hit || hit.transform.IsChildOf(actorRootTransform))
                {
                    continue;
                }

                CollectResolvedInteractables(hit, _resolvedHitInteractables);

                for (var interactableIndex = 0; interactableIndex < _resolvedHitInteractables.Count; interactableIndex++)
                {
                    var interactable = _resolvedHitInteractables[interactableIndex];
                    if (!IsInteractableAvailable(interactable))
                    {
                        continue;
                    }

                    var referenceTransform = interactable.ReferenceTransform;
                    var distance = GetInteractDistance(origin, hit, interactable, referenceTransform);
                    SetClosestCandidate(interactable, hit, distance);
                }
            }

            foreach (var kvp in _candidateColliders)
            {
                var interactable = kvp.Key;
                var hit = kvp.Value;
                if (!IsInteractableAvailable(interactable))
                {
                    continue;
                }

                if (IsInteractableSuppressed(interactable))
                {
                    continue;
                }

                _debugResolvedInteractables++;

                var referenceTransform = interactable.ReferenceTransform;
                var distance = GetInteractDistance(origin, hit, interactable, referenceTransform);
                var localMaxDistance = interactable.MaxInteractionDistance;
                var approach = 1f;
                var approachAngle = 0f;
                var facing = 1f;
                var facingAngle = 0f;
                string rejectionReason;
                var targetPoint = GetTargetPoint(origin, hit, interactable, referenceTransform);

                if (!string.IsNullOrEmpty(_requiredTag) && !interactable.TargetGameObject.CompareTag(_requiredTag))
                {
                    _debugRejectedByTag++;
                    rejectionReason = "Tag";
                    AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                    continue;
                }

                if (!IsWithinPositionConstraint(interactable, origin, targetPoint, out var positionConstraintReason))
                {
                    _debugRejectedByDistance++;
                    rejectionReason = positionConstraintReason;
                    AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                    continue;
                }

                if (!IsInsideRequiredTrigger(interactable, origin, actorRootTransform, actorColliders))
                {
                    _debugRejectedByInsideTrigger++;
                    rejectionReason = "Not Inside Trigger";
                    AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                    continue;
                }

                var requireRaycastHit = interactable.RequireRaycastHit;
                if (requireRaycastHit)
                {
#if UNITY_EDITOR
                    _debugRaycastRequired = true;
#endif
                    if (!raycastResolved)
                    {
                        ResolveRaycastInteractables(originTransform, radius);
                        raycastResolved = true;
                    }
                }

                var raycastConfirmed = raycastResolved && _raycastInteractables.Contains(interactable);
                if (requireRaycastHit && !raycastConfirmed)
                {
                    _debugRejectedByRaycast++;
                    rejectionReason = "Raycast";
                    AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                    continue;
                }

                if (interactable.RequireApproach)
                {
                    var normal = ProjectInteractionDirection(interactable, interactable.ApproachNormal);
                    if (normal.sqrMagnitude <= Mathf.Epsilon)
                    {
                        normal = ProjectInteractionDirection(interactable, interactable.GetDirectionAxisWorldVector());
                    }

                    if (normal.sqrMagnitude <= Mathf.Epsilon)
                    {
                        normal = ProjectInteractionDirection(interactable, Vector3.forward);
                    }

                    var standDirection = GetInteractionDirection(interactable,
                                                                 targetPoint,
                                                                 origin,
                                                                 referenceTransform.position);
                    if (standDirection.sqrMagnitude > Mathf.Epsilon)
                    {
                        approach = Vector3.Dot(standDirection, normal);
                        approachAngle = Vector3.Angle(standDirection, normal);
                    }
                    else
                    {
                        approach = -1f;
                        approachAngle = 180f;
                    }

                    if (approachAngle > interactable.MaxApproachAngle)
                    {
                        _debugRejectedByApproach++;
                        rejectionReason = $"Approach angle>{interactable.MaxApproachAngle:0.##}";
                        AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                        continue;
                    }
                }

                if (interactable.RequireFacing)
                {
                    var facingTargetPoint = GetFacingTargetPoint(origin,
                                                                 hit,
                                                                 interactable,
                                                                 targetPoint);
                    var lookDirection = GetInteractionDirection(interactable,
                                                                origin,
                                                                facingTargetPoint,
                                                                referenceTransform.position);
                    var actorForward = ProjectInteractionDirection(interactable, originTransform.forward);
                    if (lookDirection.sqrMagnitude > Mathf.Epsilon && actorForward.sqrMagnitude > Mathf.Epsilon)
                    {
                        facing = Vector3.Dot(actorForward, lookDirection);
                        facingAngle = Vector3.Angle(actorForward, lookDirection);
                    }
                    else
                    {
                        facing = -1f;
                        facingAngle = 180f;
                    }

                    if (facingAngle > interactable.MaxFacingAngle)
                    {
                        _debugRejectedByFacing++;
                        rejectionReason = $"Facing angle>{interactable.MaxFacingAngle:0.##}";
                        AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, rejectionReason);
                        continue;
                    }
                }

                SetMinDistance(_currentValidInteractables, interactable, distance);
                _currentPassiveCandidates[interactable] = new PassiveCandidateInfo(distance, approach, facing);

                if (IsBetterCandidate(interactable,
                                      distance,
                                      approach,
                                      bestHoverInteractable,
                                      bestHoverDistance,
                                      bestHoverApproach))
                {
                    bestHoverInteractable = interactable;
                    bestHoverDistance = distance;
                    bestHoverApproach = approach;
                }

                _debugValidCandidates++;
                AppendCandidateDebug(interactable, origin, targetPoint, distance, localMaxDistance, approach, approachAngle, facing, facingAngle, "Valid");
            }

            if (TryGetLockedInteractable(origin,
                                         radius,
                                         bestHoverDistance,
                                         out var lockedInteractable,
                                         out var lockedDistance))
            {
                _currentLockedInteractable = lockedInteractable;
                _currentLockedDistance = lockedDistance;
            }

            var outputInteractable = bestHoverInteractable;
            var outputDistance = bestHoverDistance;
            if (_currentLockedInteractable)
            {
                outputInteractable = _currentLockedInteractable;
                outputDistance = _currentLockedDistance;
            }

            if (outputInteractable)
            {
                CurrentSelectionInteractable = outputInteractable;
                CurrentSelectionTarget = outputInteractable.TargetGameObject;
                CurrentInteraction = outputInteractable.Interaction;
                CurrentActivationId = outputInteractable.ActivationId;
                CurrentNormal = outputInteractable.ApproachNormal.normalized;
                CurrentSelectionDistance = outputDistance;
            }
            else
            {
                ClearSelectionOutputs();
            }

            UpdateValidTargets(originTransform);
            UpdateHoverTarget(originTransform, bestHoverInteractable, bestHoverDistance);
            CanInteract = false;
            _lastPassiveUpdateFrame = Time.frameCount;
            _passiveStateDirty = false;
        }

        public bool TryActivate(bool interactPressed, string activationId)
        {
            EnsurePassiveStateUpdated();
            DidActivateThisUpdate = false;
            _debugHasActivationAttempt = true;
            _debugLastInteractPressed = interactPressed;
            _debugLastInputActivationId = activationId ?? string.Empty;

            if (!TryGetActivationCandidate(interactPressed,
                                           activationId,
                                           out var bestInteractable,
                                           out var bestDistance,
                                           out var bestApproach,
                                           out var bestFacing))
            {
                ClearActiveInteraction();
                CanInteract = false;
                return false;
            }

            _debugBestTargetName = bestInteractable.TargetGameObject.name;
            _debugBestType = bestInteractable.Interaction;
            _debugBestDistance = bestDistance;
            _debugBestApproach = bestApproach;
            _debugBestFacing = bestFacing;

            CanInteract = true;

            if (_previousActivatedInteractable != bestInteractable)
            {
                _previousActivatedInteractable = bestInteractable;
                var actorTransform = ResolveActorTransform();
                if (actorTransform)
                {
                    SendInteractSystemEvent(actorTransform, bestInteractable, bestDistance, OnInteractEvent.Get);
                }

                DidActivateThisUpdate = true;
            }

            return true;
        }

        public void ClearHover()
        {
            ClearHoverTarget(ResolveActorTransform());
        }

        public void ClearActiveInteraction()
        {
            _previousActivatedInteractable = null;
        }

        public void ResetRuntimeState()
        {
            var actorTransform = ResolveActorTransform();
            _currentValidInteractables.Clear();
            _currentPassiveCandidates.Clear();
            _pendingSystemEvents.Clear();
            UpdateValidTargets(actorTransform);
            ClearHoverTarget(actorTransform);
            ClearActiveInteraction();
            ClearOutputs();
            _currentLockedInteractable = null;
            _currentLockedDistance = 0f;
            _suppressedInteractables.Clear();
            _wasLockActiveInteraction = false;
            _deferSystemEvents = false;
            _lastPassiveUpdateFrame = -1;
            _passiveStateDirty = true;
            DidActivateThisUpdate = false;
        }

        public void InvalidatePassiveState()
        {
            _passiveStateDirty = true;
            _lastPassiveUpdateFrame = -1;
        }

        public void StopHoverTracking()
        {
            var actorTransform = ResolveActorTransform();
            _currentValidInteractables.Clear();
            _currentPassiveCandidates.Clear();
            _pendingSystemEvents.Clear();
            UpdateValidTargets(actorTransform);
            ClearHoverTarget(actorTransform);
            ClearOutputs();
            _currentLockedInteractable = null;
            _currentLockedDistance = 0f;
            _wasLockActiveInteraction = false;
            _deferSystemEvents = false;
            _lastPassiveUpdateFrame = -1;
            _passiveStateDirty = true;
            DidActivateThisUpdate = false;
        }

        public void SuppressInteractable(Interactable interactable, float duration)
        {
            if (!interactable)
            {
                return;
            }

            duration = Mathf.Max(0f, duration);
            if (duration <= Mathf.Epsilon)
            {
                _suppressedInteractables.Remove(interactable);
                return;
            }

            if (_previousActivatedInteractable == interactable)
            {
                ClearActiveInteraction();
            }

            _suppressedInteractables[interactable] = Time.unscaledTime + duration;
            InvalidatePassiveState();
        }

        private bool TryGetActivationCandidate(bool interactPressed,
                                               string activationId,
                                               out Interactable bestInteractable,
                                               out float bestDistance,
                                               out float bestApproach,
                                               out float bestFacing)
        {
            bestInteractable = null;
            bestDistance = float.PositiveInfinity;
            bestApproach = -1f;
            bestFacing = -1f;

            if (_currentLockedInteractable)
            {
                bestInteractable = _currentLockedInteractable;
                bestDistance = _currentLockedDistance;
                bestApproach = 0f;
                bestFacing = 0f;
                return true;
            }

            foreach (var kvp in _currentPassiveCandidates)
            {
                var interactable = kvp.Key;
                if (!IsInteractableAvailable(interactable))
                {
                    continue;
                }

                if (IsInteractableSuppressed(interactable))
                {
                    continue;
                }

                if (interactable.IsExplicitInteraction)
                {
                    if (!interactPressed)
                    {
                        _debugRejectedByUse++;
                        continue;
                    }

                    if (!MatchesActivationId(interactable, activationId))
                    {
                        _debugRejectedByUse++;
                        continue;
                    }
                }

                var candidate = kvp.Value;
                if (!IsBetterCandidate(interactable,
                                       candidate.Distance,
                                       candidate.Approach,
                                       bestInteractable,
                                       bestDistance,
                                       bestApproach,
                                       interactPressed))
                {
                    continue;
                }

                bestInteractable = interactable;
                bestDistance = candidate.Distance;
                bestApproach = candidate.Approach;
                bestFacing = candidate.Facing;
            }

            return bestInteractable;
        }

#if UNITY_EDITOR
        public bool HasDebugInfo => true;
        public IReadOnlyList<DebugCandidateInfo> DebugCandidates => _debugCandidateInfos;
        public bool DebugUpdatedThisFrame => _lastPassiveUpdateFrame == Time.frameCount;
        public int DebugLastPassiveUpdateFrame => _lastPassiveUpdateFrame;
        public Transform DebugResolvedReferenceTransform => ResolveActorTransform();
        public Interactable DebugLockedInteractable => _currentLockedInteractable;
        public bool DebugUsingLockedInteractable => _currentLockedInteractable && CurrentSelectionInteractable == _currentLockedInteractable;
        public int DebugHitCount => _debugHitCount;
        public int DebugResolvedInteractables => _debugResolvedInteractables;
        public int DebugValidCandidates => _debugValidCandidates;
        public bool DebugRaycastRequired => _debugRaycastRequired;
        public bool DebugRaycastHit => _debugRaycastHit;
        public int DebugRejectedByTag => _debugRejectedByTag;
        public int DebugRejectedByUse => _debugRejectedByUse;
        public int DebugRejectedByDistance => _debugRejectedByDistance;
        public int DebugRejectedByInsideTrigger => _debugRejectedByInsideTrigger;
        public int DebugRejectedByApproach => _debugRejectedByApproach;
        public int DebugRejectedByFacing => _debugRejectedByFacing;
        public int DebugRejectedByRaycast => _debugRejectedByRaycast;
        public string DebugBestTargetName => _debugBestTargetName;
        public string DebugBestType => _debugBestType;
        public float DebugBestDistance => _debugBestDistance;
        public float DebugBestApproach => _debugBestApproach;
        public float DebugBestFacing => _debugBestFacing;
        public bool DebugHasActivationAttempt => _debugHasActivationAttempt;
        public bool DebugLastInteractPressed => _debugLastInteractPressed;
        public string DebugLastInputActivationId => _debugLastInputActivationId;
        public string DebugActivationState => GetDebugActivationState();

        public string GetDebugInfo()
        {
            var selected = string.IsNullOrEmpty(_debugBestTargetName)
                ? "none"
                : $"{_debugBestTargetName} ({_debugBestType})  distance={_debugBestDistance:0.##}  approach={_debugBestApproach:0.##}  facing={_debugBestFacing:0.##}";

            var raycastSummary = _debugRaycastRequired ? $"  RaycastHit={_debugRaycastHit}" : string.Empty;

            return $"Scan: Hits={_debugHitCount}  Interactables={_debugResolvedInteractables}  Valid={_debugValidCandidates}{raycastSummary}\n" +
                   $"Rejected: Tag={_debugRejectedByTag}  Interact={_debugRejectedByUse}  Distance={_debugRejectedByDistance}  InsideTrigger={_debugRejectedByInsideTrigger}  Approach={_debugRejectedByApproach}  Facing={_debugRejectedByFacing}  Raycast={_debugRejectedByRaycast}\n" +
                   $"Activation: {GetDebugActivationState()}\n" +
                   $"Selected: {selected}" +
                   (_debugCandidates.Length > 0 ? $"\n{_debugCandidates}" : string.Empty);
        }
#endif

        private Transform ResolveActorTransform()
        {
            if (_referenceTransform != null)
            {
                return _referenceTransform;
            }

            return transform;
        }

        private void ClearOutputs()
        {
            CanInteract = false;
            ClearSelectionOutputs();
        }

        private void ClearSelectionOutputs()
        {
            CurrentSelectionInteractable = null;
            CurrentSelectionTarget = null;
            CurrentSelectionDistance = 0f;
            CurrentInteraction = string.Empty;
            CurrentActivationId = string.Empty;
            CurrentNormal = Vector3.zero;
        }

        private void UpdateValidTargets(Transform actorTransform)
        {
            foreach (var kvp in _currentValidInteractables)
            {
                if (!kvp.Key || _previousValidInteractables.ContainsKey(kvp.Key))
                {
                    continue;
                }

                SendInteractSystemEvent(actorTransform, kvp.Key, kvp.Value, OnInteractAvailableEvent.Get);
            }

            foreach (var kvp in _previousValidInteractables)
            {
                if (!kvp.Key || _currentValidInteractables.ContainsKey(kvp.Key))
                {
                    continue;
                }

                SendInteractSystemEvent(actorTransform, kvp.Key, kvp.Value, OnInteractUnavailableEvent.Get);
            }

            _previousValidInteractables.Clear();
            foreach (var kvp in _currentValidInteractables)
            {
                if (kvp.Key)
                {
                    _previousValidInteractables[kvp.Key] = kvp.Value;
                }
            }
        }

        private void UpdateHoverTarget(Transform actorTransform, Interactable bestInteractable, float bestDistance)
        {
            if (_previousHoverInteractable == bestInteractable)
            {
                _previousHoverDistance = bestDistance;
                CurrentHoverInteractable = bestInteractable;
                CurrentHoverTarget = bestInteractable ? bestInteractable.TargetGameObject : null;
                CurrentHoverDistance = bestInteractable ? bestDistance : 0f;
                return;
            }

            if (_previousHoverInteractable)
            {
                SendInteractSystemEvent(actorTransform,
                                        _previousHoverInteractable,
                                        _previousHoverDistance,
                                        OnInteractLostFocusEvent.Get);
            }

            _previousHoverInteractable = bestInteractable;
            _previousHoverDistance = bestDistance;
            CurrentHoverInteractable = bestInteractable;
            CurrentHoverTarget = bestInteractable ? bestInteractable.TargetGameObject : null;
            CurrentHoverDistance = bestInteractable ? bestDistance : 0f;

            if (_previousHoverInteractable)
            {
                SendInteractSystemEvent(actorTransform,
                                        _previousHoverInteractable,
                                        _previousHoverDistance,
                                        OnInteractFocusEvent.Get);
            }
        }

        private void ClearHoverTarget(Transform actorTransform)
        {
            if (!actorTransform || !_previousHoverInteractable)
            {
                _previousHoverInteractable = null;
                _previousHoverDistance = 0f;
                CurrentHoverInteractable = null;
                CurrentHoverTarget = null;
                CurrentHoverDistance = 0f;
                return;
            }

            SendInteractSystemEvent(actorTransform,
                                    _previousHoverInteractable,
                                    _previousHoverDistance,
                                    OnInteractLostFocusEvent.Get);

            _previousHoverInteractable = null;
            _previousHoverDistance = 0f;
            CurrentHoverInteractable = null;
            CurrentHoverTarget = null;
            CurrentHoverDistance = 0f;
        }

        private void SendInteractSystemEvent(Transform actorTransform,
                                             Interactable interactable,
                                             float distance,
                                             Func<Transform, Interactable, GameObject, Transform, string, string, Vector3, float, InteractSystemEventBase> eventFactory)
        {
            if (_deferSystemEvents)
            {
                _pendingSystemEvents.Add(new PendingInteractSystemEvent(actorTransform, interactable, distance, eventFactory));
                return;
            }

            DispatchInteractSystemEventNow(actorTransform, interactable, distance, eventFactory);
        }

        private void DispatchInteractSystemEventNow(Transform actorTransform,
                                                    Interactable interactable,
                                                    float distance,
                                                    Func<Transform, Interactable, GameObject, Transform, string, string, Vector3, float, InteractSystemEventBase> eventFactory)
        {
            if (!actorTransform || !interactable)
            {
                return;
            }

            var targetGameObject = interactable.TargetGameObject;
            var eventTemplate = eventFactory(actorTransform,
                                             interactable,
                                             targetGameObject,
                                             interactable.ReferenceTransform,
                                             interactable.Interaction,
                                             interactable.ActivationId,
                                             interactable.ApproachNormal.normalized,
                                             distance);

            var evt = eventTemplate.GetRuntimeEvent(new EventSender(this));
            DispatchInteractSystemEvent(targetGameObject, evt);

            var actorGameObject = actorTransform.gameObject;
            if (actorGameObject != targetGameObject)
            {
                DispatchInteractSystemEvent(actorGameObject, evt);
            }
        }

        private static void DispatchInteractSystemEvent(GameObject gameObject, BaseEvent evt)
        {
            if (!gameObject || evt == null)
            {
                return;
            }

            var fsmComponents = gameObject.GetComponents<BaseFsmComponent>();
            foreach (var fsmComponent in fsmComponents)
            {
                fsmComponent.OnEvent(evt);
            }
        }

        private bool TryGetLockedInteractable(Vector3 origin,
                                              float searchRadius,
                                              float currentBestDistance,
                                              out Interactable lockedInteractable,
                                              out float lockedDistance)
        {
            lockedInteractable = null;
            lockedDistance = currentBestDistance;

            if (!_wasLockActiveInteraction || !_previousActivatedInteractable)
            {
                return false;
            }

            if (IsInteractableSuppressed(_previousActivatedInteractable))
            {
                return false;
            }

            if (!TryEvaluateLockedInteractable(_previousActivatedInteractable, origin, searchRadius, out var candidateDistance))
            {
                return false;
            }

            lockedInteractable = _previousActivatedInteractable;
            lockedDistance = candidateDistance;
            return true;
        }

        private bool TryEvaluateLockedInteractable(Interactable interactable,
                                                   Vector3 origin,
                                                   float searchRadius,
                                                   out float distance)
        {
            distance = 0f;
            var actorRootTransform = transform;
            var actorColliders = actorRootTransform.GetComponentsInChildren<Collider>(true);

            if (!IsInteractableAvailable(interactable))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(_requiredTag) && !interactable.TargetGameObject.CompareTag(_requiredTag))
            {
                return false;
            }

            if (!IsInsideRequiredTrigger(interactable, origin, actorRootTransform, actorColliders))
            {
                return false;
            }

            var referenceTransform = interactable.ReferenceTransform;
            if (!referenceTransform)
            {
                return false;
            }

            var targetPoint = referenceTransform.position;
            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider &&
                TryGetClosestCollider(interactable, out var closestCollider) &&
                closestCollider != null)
            {
                targetPoint = GetClosestPointForMeasurement(origin,
                                                            referenceTransform.position,
                                                            closestCollider,
                                                            interactable);
            }

            distance = GetMeasuredDistance(interactable, origin, targetPoint);
            if (distance > searchRadius)
            {
                return false;
            }

            return IsWithinPositionConstraint(interactable, origin, targetPoint, out _);
        }

        private static bool IsInsideRequiredTrigger(Interactable interactable,
                                                    Vector3 origin,
                                                    Transform actorRootTransform,
                                                    Collider[] actorColliders)
        {
            var insideTrigger = interactable.InsideTrigger;
            if (!insideTrigger)
            {
                return true;
            }

            if (!insideTrigger.enabled || !insideTrigger.gameObject.activeInHierarchy)
            {
                return false;
            }

            return DoesActorOverlapTrigger(actorRootTransform, actorColliders, insideTrigger);
        }

        private static bool DoesActorOverlapTrigger(Transform actorRootTransform,
                                                    Collider[] actorColliders,
                                                    Collider insideTrigger)
        {
            if (!actorRootTransform || !PhysicsColliderQueries.TryOverlapCollider(insideTrigger,
                    Physics.AllLayers,
                    QueryTriggerInteraction.Collide,
                    out var overlaps))
            {
                return false;
            }

            if (actorColliders == null || actorColliders.Length == 0)
            {
                return false;
            }

            for (var overlapIndex = 0; overlapIndex < overlaps.Length; overlapIndex++)
            {
                var overlap = overlaps[overlapIndex];
                if (!overlap || !overlap.transform.IsChildOf(actorRootTransform))
                {
                    continue;
                }

                for (var actorColliderIndex = 0; actorColliderIndex < actorColliders.Length; actorColliderIndex++)
                {
                    if (overlap == actorColliders[actorColliderIndex])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool TryGetClosestCollider(Interactable interactable, out Collider closestCollider)
        {
            closestCollider = null;

            var colliders = interactable.GetComponentsInChildren<Collider>(true);
            var hasCollider = false;
            var closestDistance = float.PositiveInfinity;
            var referencePosition = interactable.ReferenceTransform ? interactable.ReferenceTransform.position : interactable.transform.position;

            for (var i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (!collider || !collider.enabled || !collider.gameObject.activeInHierarchy)
                {
                    continue;
                }

                hasCollider = true;
                var point = collider.ClosestPoint(referencePosition);
                var distance = (point - referencePosition).sqrMagnitude;
                if (distance >= closestDistance)
                {
                    continue;
                }

                closestDistance = distance;
                closestCollider = collider;
            }

            return hasCollider;
        }

        private static float GetInteractDistance(Vector3 origin, Collider hit, Interactable interactable, Transform anchor)
        {
            if (!interactable || !anchor)
            {
                return float.PositiveInfinity;
            }

            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider && hit != null)
            {
                var closestPoint = GetClosestPointForMeasurement(origin,
                                                                 anchor.position,
                                                                 hit,
                                                                 interactable);
                return GetMeasuredDistance(interactable, origin, closestPoint);
            }

            return GetMeasuredDistance(interactable, origin, anchor.position);
        }

        private static Vector3 GetTargetPoint(Vector3 origin, Collider hit, Interactable interactable, Transform anchor)
        {
            if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider && hit != null)
            {
                return GetClosestPointForMeasurement(origin,
                                                     anchor.position,
                                                     hit,
                                                     interactable);
            }

            return anchor.position;
        }

        private static Vector3 GetFacingTargetPoint(Vector3 origin,
                                                    Collider hit,
                                                    Interactable interactable,
                                                    Vector3 defaultTargetPoint)
        {
            if (interactable.DistanceFrom != Interactable.DistanceFromMode.Collider || hit == null)
            {
                return defaultTargetPoint;
            }

            if (!PhysicsColliderQueries.TryContainsPoint(hit, origin))
            {
                return defaultTargetPoint;
            }

            return hit.bounds.center;
        }

        private static Vector3 GetClosestPointForMeasurement(Vector3 origin,
                                                             Vector3 referencePosition,
                                                             Collider collider,
                                                             Interactable interactable)
        {
            var queryPoint = ApplyMeasurementAxis(interactable, referencePosition, origin);
            var closestPoint = collider.ClosestPoint(queryPoint);
            if ((closestPoint - queryPoint).sqrMagnitude > Mathf.Epsilon)
            {
                return closestPoint;
            }

            if (PhysicsColliderQueries.TryContainsPoint(collider, queryPoint))
            {
                if (PhysicsColliderQueries.TryGetClosestSurfacePoint(collider, queryPoint, out var surfacePoint))
                {
                    return surfacePoint;
                }

                return collider.ClosestPointOnBounds(queryPoint);
            }

            return closestPoint;
        }

        private static Vector3 ProjectInteractionDirection(Interactable interactable, Vector3 direction)
        {
            if (!interactable)
            {
                return direction.sqrMagnitude <= Mathf.Epsilon ? Vector3.zero : direction.normalized;
            }

            var projected = ProjectInteractionVector(interactable, direction);
            return projected.sqrMagnitude <= Mathf.Epsilon ? Vector3.zero : projected.normalized;
        }

        private static Vector3 GetInteractionDirection(Interactable interactable,
                                                       Vector3 from,
                                                       Vector3 primaryTarget,
                                                       Vector3 fallbackTarget)
        {
            var direction = ProjectInteractionDirection(interactable, primaryTarget - from);
            if (direction.sqrMagnitude > Mathf.Epsilon)
            {
                return direction;
            }

            return ProjectInteractionDirection(interactable, fallbackTarget - from);
        }

        private static Vector3 ProjectInteractionVector(Interactable interactable, Vector3 direction)
        {
            var axis = interactable.MeasurementAxis;
            if (interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.World)
            {
                return MoveAxisHelper.ProjectToAxis(axis, direction);
            }

            var referenceTransform = interactable.ReferenceTransform;
            if (!referenceTransform)
            {
                return MoveAxisHelper.ProjectToAxis(axis, direction);
            }

            var localDirection = referenceTransform.InverseTransformDirection(direction);
            var localProjected = MoveAxisHelper.ProjectToAxis(axis, localDirection);
            return referenceTransform.TransformDirection(localProjected);
        }

        private static float GetMeasuredDistance(Interactable interactable, Vector3 from, Vector3 to)
        {
            if (!interactable)
            {
                return Vector3.Distance(from, to);
            }

            return ProjectInteractionVector(interactable, to - from).magnitude;
        }

        private static bool IsWithinPositionConstraint(Interactable interactable,
                                                       Vector3 from,
                                                       Vector3 to,
                                                       out string rejectionReason)
        {
            rejectionReason = string.Empty;
            if (!interactable)
            {
                return true;
            }

            if (interactable.PositionDistanceMode == Interactable.PositionConstraintMode.Box)
            {
                return IsWithinBoxPositionConstraint(interactable, from, to, out rejectionReason);
            }

            var distance = GetMeasuredDistance(interactable, from, to);
            var localMinDistance = interactable.MinInteractionDistance;
            if (localMinDistance > 0f && distance < localMinDistance)
            {
                rejectionReason = $"Distance local<{localMinDistance:0.##}";
                return false;
            }

            var localMaxDistance = interactable.MaxInteractionDistance;
            if (localMaxDistance <= 0f || distance <= localMaxDistance)
            {
                return true;
            }

            rejectionReason = $"Distance local>{localMaxDistance:0.##}";
            return false;
        }

        private static bool IsWithinBoxPositionConstraint(Interactable interactable,
                                                          Vector3 from,
                                                          Vector3 to,
                                                          out string rejectionReason)
        {
            rejectionReason = string.Empty;
            var maxPositionDelta = interactable.MaxPositionDelta;
            if (maxPositionDelta.x <= 0f && maxPositionDelta.y <= 0f && maxPositionDelta.z <= 0f)
            {
                return true;
            }

            var offset = GetMeasurementOffset(interactable, from, to);
            var absOffset = new Vector3(Mathf.Abs(offset.x), Mathf.Abs(offset.y), Mathf.Abs(offset.z));

            if (maxPositionDelta.x > 0f && absOffset.x > maxPositionDelta.x)
            {
                rejectionReason = $"Box X>{maxPositionDelta.x:0.##} ({absOffset.x:0.##})";
                return false;
            }

            if (maxPositionDelta.y > 0f && absOffset.y > maxPositionDelta.y)
            {
                rejectionReason = $"Box Y>{maxPositionDelta.y:0.##} ({absOffset.y:0.##})";
                return false;
            }

            if (maxPositionDelta.z > 0f && absOffset.z > maxPositionDelta.z)
            {
                rejectionReason = $"Box Z>{maxPositionDelta.z:0.##} ({absOffset.z:0.##})";
                return false;
            }

            return true;
        }

        private static Vector3 GetMeasurementOffset(Interactable interactable, Vector3 from, Vector3 to)
        {
            var direction = to - from;
            if (interactable &&
                interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.ReferenceTransform)
            {
                var referenceTransform = interactable.ReferenceTransform;
                if (referenceTransform)
                {
                    return referenceTransform.InverseTransformDirection(direction);
                }
            }

            return direction;
        }

        private static Vector3 ApplyMeasurementAxis(Interactable interactable, Vector3 from, Vector3 to)
        {
            if (!interactable || interactable.InteractionMeasurementSpace == Interactable.MeasurementSpace.World)
            {
                return MoveAxisHelper.Apply(interactable ? interactable.MeasurementAxis : MoveAxis.XYZ, from, to);
            }

            var referenceTransform = interactable.ReferenceTransform;
            if (!referenceTransform)
            {
                return MoveAxisHelper.Apply(interactable.MeasurementAxis, from, to);
            }

            var localFrom = referenceTransform.InverseTransformPoint(from);
            var localTo = referenceTransform.InverseTransformPoint(to);
            var localApplied = MoveAxisHelper.Apply(interactable.MeasurementAxis, localFrom, localTo);
            return referenceTransform.TransformPoint(localApplied);
        }

        private static bool IsBetterCandidate(Interactable candidate,
                                              float candidateDistance,
                                              float candidateApproach,
                                              Interactable currentBest,
                                              float currentBestDistance,
                                              float currentBestApproach,
                                              bool explicitInteractionPreferred = false)
        {
            if (!currentBest)
            {
                return true;
            }

            if (explicitInteractionPreferred &&
                candidate.IsExplicitInteraction != currentBest.IsExplicitInteraction)
            {
                return candidate.IsExplicitInteraction;
            }

            if (candidate.Priority != currentBest.Priority)
            {
                return candidate.Priority > currentBest.Priority;
            }

            if (candidateDistance < currentBestDistance - Mathf.Epsilon)
            {
                return true;
            }

            return Mathf.Abs(candidateDistance - currentBestDistance) <= Mathf.Epsilon &&
                   candidateApproach > currentBestApproach;
        }

        private static bool MatchesActivationId(Interactable interactable, string currentActivationId)
        {
            if (!interactable)
            {
                return false;
            }

            if (string.IsNullOrEmpty(interactable.ActivationId))
            {
                return true;
            }

            return string.Equals(interactable.ActivationId, currentActivationId, StringComparison.Ordinal);
        }

        private static bool IsInteractableAvailable(Interactable interactable)
        {
            return interactable && interactable.isActiveAndEnabled && interactable.IsEnabled;
        }

        private bool IsInteractableSuppressed(Interactable interactable)
        {
            if (!interactable)
            {
                return false;
            }

            if (!_suppressedInteractables.TryGetValue(interactable, out var suppressedUntil))
            {
                return false;
            }

            if (Time.unscaledTime < suppressedUntil)
            {
                return true;
            }

            _suppressedInteractables.Remove(interactable);
            return false;
        }

        private void RemoveExpiredSuppressedInteractables()
        {
            if (_suppressedInteractables.Count == 0)
            {
                return;
            }

            List<Interactable> expired = null;
            foreach (var kvp in _suppressedInteractables)
            {
                if (kvp.Key && Time.unscaledTime < kvp.Value)
                {
                    continue;
                }

                expired ??= new List<Interactable>();
                expired.Add(kvp.Key);
            }

            if (expired == null)
            {
                return;
            }

            for (var i = 0; i < expired.Count; i++)
            {
                _suppressedInteractables.Remove(expired[i]);
            }
        }

        private void ResolveRaycastInteractables(Transform originTransform, float radius)
        {
            _raycastInteractables.Clear();

            var hitCount = Physics.RaycastNonAlloc(originTransform.position,
                                                   originTransform.forward,
                                                   _raycastHits,
                                                   radius,
                                                   _blockingLayers,
                                                   _hitTriggers);

            if (hitCount <= 0)
            {
#if UNITY_EDITOR
                _debugRaycastHit = false;
#endif
                return;
            }

            var nearestDistance = float.PositiveInfinity;
            Collider nearestCollider = null;
            for (var i = 0; i < hitCount; ++i)
            {
                var hit = _raycastHits[i];
                if (hit.collider == null)
                {
                    continue;
                }

                if (hit.distance >= nearestDistance)
                {
                    continue;
                }

                nearestDistance = hit.distance;
                nearestCollider = hit.collider;
            }

            if (!nearestCollider)
            {
#if UNITY_EDITOR
                _debugRaycastHit = false;
#endif
                return;
            }

            CollectResolvedInteractables(nearestCollider, _resolvedHitInteractables);
            for (var i = 0; i < _resolvedHitInteractables.Count; i++)
            {
                var interactable = _resolvedHitInteractables[i];
                if (IsInteractableAvailable(interactable) && DoesRaycastHitInteractable(interactable, nearestCollider))
                {
                    _raycastInteractables.Add(interactable);
                }
            }

#if UNITY_EDITOR
            _debugRaycastHit = _raycastInteractables.Count > 0;
#endif
        }

        private static bool DoesRaycastHitInteractable(Interactable interactable, Collider hitCollider)
        {
            if (!interactable || !hitCollider)
            {
                return false;
            }

            var ownedColliders = interactable.GetComponentsInChildren<Collider>(true);
            var hasOwnedCollider = false;
            for (var i = 0; i < ownedColliders.Length; i++)
            {
                var collider = ownedColliders[i];
                if (!collider || !collider.enabled || !collider.gameObject.activeInHierarchy)
                {
                    continue;
                }

                hasOwnedCollider = true;
                if (collider == hitCollider)
                {
                    return true;
                }
            }

            if (hasOwnedCollider)
            {
                return false;
            }

            return DoesColliderResolveInteractable(hitCollider, interactable);
        }

        private static bool DoesColliderResolveInteractable(Collider collider, Interactable interactable)
        {
            if (!collider || !interactable)
            {
                return false;
            }

            var current = collider.transform;
            while (current != null)
            {
                var resolvedInteractables = current.GetComponentsInChildren<Interactable>(true);
                if (resolvedInteractables.Length > 0)
                {
                    for (var i = 0; i < resolvedInteractables.Length; i++)
                    {
                        var resolved = resolvedInteractables[i];
                        if (resolved != interactable)
                        {
                            continue;
                        }

                        if (resolved.transform == current)
                        {
                            return true;
                        }

                        return resolved.transform.parent != null && resolved.transform.parent.IsChildOf(current);
                    }

                    return false;
                }

                current = current.parent;
            }

            return false;
        }

        private static void CollectResolvedInteractables(Collider collider, List<Interactable> results)
        {
            results.Clear();
            if (!collider)
            {
                return;
            }

            var current = collider.transform;
            while (current != null)
            {
                current.GetComponentsInChildren(true, results);
                if (results.Count > 0)
                {
                    for (var i = results.Count - 1; i >= 0; i--)
                    {
                        if (results[i] == null || results[i].transform == current)
                        {
                            continue;
                        }

                        if (results[i].transform.parent == null || !results[i].transform.parent.IsChildOf(current))
                        {
                            results.RemoveAt(i);
                        }
                    }

                    return;
                }

                current = current.parent;
            }
        }

        private void ResetDebugInfo()
        {
            _debugHitCount = 0;
#if UNITY_EDITOR
            _debugRaycastRequired = false;
            _debugRaycastHit = false;
#endif
            _debugResolvedInteractables = 0;
            _debugRejectedByTag = 0;
            _debugRejectedByUse = 0;
            _debugRejectedByDistance = 0;
            _debugRejectedByInsideTrigger = 0;
            _debugRejectedByApproach = 0;
            _debugRejectedByFacing = 0;
            _debugRejectedByRaycast = 0;
            _debugValidCandidates = 0;
            _debugBestTargetName = string.Empty;
            _debugBestType = string.Empty;
            _debugBestDistance = 0f;
            _debugBestApproach = 0f;
            _debugBestFacing = 0f;
            _debugHasActivationAttempt = false;
            _debugLastInteractPressed = false;
            _debugLastInputActivationId = string.Empty;
#if UNITY_EDITOR
            _debugCandidates.Length = 0;
            _debugCandidateInfos.Clear();
#endif
        }

        private string GetDebugActivationState()
        {
            if (!_debugHasActivationAttempt)
            {
                return "No activation attempt recorded";
            }

            var selectedInteractable = _currentLockedInteractable ? _currentLockedInteractable : CurrentSelectionInteractable;
            if (!selectedInteractable)
            {
                return "No selected interactable";
            }

            if (!selectedInteractable.IsExplicitInteraction)
            {
                return "Passive interaction";
            }

            if (!_debugLastInteractPressed)
            {
                return string.IsNullOrEmpty(selectedInteractable.ActivationId)
                    ? "Waiting for activation press"
                    : $"Waiting for activation press ({selectedInteractable.ActivationId})";
            }

            if (!MatchesActivationId(selectedInteractable, _debugLastInputActivationId))
            {
                return $"ActivationId mismatch: expected '{selectedInteractable.ActivationId}', got '{_debugLastInputActivationId}'";
            }

            return _previousActivatedInteractable == selectedInteractable
                ? "Activated"
                : "Activation input matched";
        }

        private void AppendCandidateDebug(Interactable interactable,
                                          Vector3 origin,
                                          Vector3 targetPoint,
                                          float distance,
                                          float localMaxDistance,
                                          float approach,
                                          float approachAngle,
                                          float facing,
                                          float facingAngle,
                                          string result)
        {
#if UNITY_EDITOR
            if (_debugCandidates.Length > 0)
            {
                _debugCandidates.Append("\n\n");
            }

            var rawDistance = Vector3.Distance(origin, targetPoint);

            _debugCandidates.Append("Candidate: ")
                            .Append(interactable.gameObject.name)
                            .Append(" (")
                            .Append(interactable.Interaction)
                            .Append(')')
                            .Append("\n  Distance: ")
                            .Append(distance.ToString("0.##"))
                            .Append(" [")
                            .Append(interactable.MeasurementAxis)
                            .Append("]")
                            .Append("  Raw3D: ")
                            .Append(rawDistance.ToString("0.##"))
                            .Append("  Limit: ")
                            .Append(localMaxDistance > 0f ? localMaxDistance.ToString("0.##") : "off")
                            .Append("\n  Mode: ")
                            .Append(interactable.DistanceFrom)
                            .Append("  Axis: ")
                            .Append(interactable.MeasurementAxis)
                            .Append("\n  Approach: dot=")
                            .Append(approach.ToString("0.##"))
                            .Append("  angle=")
                            .Append(approachAngle.ToString("0.##"))
                            .Append('/')
                            .Append(interactable.MaxApproachAngle.ToString("0.##"))
                            .Append("\n  Facing: dot=")
                            .Append(facing.ToString("0.##"))
                            .Append("  angle=")
                            .Append(facingAngle.ToString("0.##"))
                            .Append('/')
                            .Append(interactable.MaxFacingAngle.ToString("0.##"))
                            .Append("\n  Result: ")
                            .Append(result);

            _debugCandidateInfos.Add(new DebugCandidateInfo(interactable,
                                                            distance,
                                                            rawDistance,
                                                            localMaxDistance,
                                                            approach,
                                                            approachAngle,
                                                            interactable.MaxApproachAngle,
                                                            facing,
                                                            facingAngle,
                                                            interactable.MaxFacingAngle,
                                                            result));
#endif
        }

        private static void SetMinDistance(IDictionary<Interactable, float> values, Interactable interactable, float distance)
        {
            if (!values.TryGetValue(interactable, out var currentDistance) || distance < currentDistance)
            {
                values[interactable] = distance;
            }
        }

        private void SetClosestCandidate(Interactable interactable, Collider hit, float distance)
        {
            if (!_candidateColliders.TryGetValue(interactable, out _))
            {
                _candidateColliders.Add(interactable, hit);
                _candidateColliderDistances.Add(interactable, distance);
                return;
            }

            if (!_candidateColliderDistances.TryGetValue(interactable, out var currentDistance) || distance < currentDistance)
            {
                _candidateColliders[interactable] = hit;
                _candidateColliderDistances[interactable] = distance;
            }
        }

        private void SetField<T>(ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            _passiveStateDirty = true;
        }
    }
}
