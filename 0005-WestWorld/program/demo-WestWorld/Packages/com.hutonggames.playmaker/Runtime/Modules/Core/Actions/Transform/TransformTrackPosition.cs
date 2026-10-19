using System;
using UnityEngine;
using HutongGames.PlayMaker.Internal;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ActionDescription("Track a transform's position over time and provide useful stats. " +
                       "Starts tracking when the state is entered and stops when the state is exited.")]
    [HelpURL("actions/transform-actions/tracking-actions/")]
    public sealed class TransformTrackPosition : BaseAction
    {
        private const float MinSampleDeltaTime = 0.0001f;

        // Run every frame in LateUpdate so we naturally execute after setters in Update
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        // ─────────────────────────────────────────────────────────────────────────
        // Inputs
        // ─────────────────────────────────────────────────────────────────────────
        
        [Note("If the GameObject has a non-kinematic Rigidbody or Rigidbody2D, " +
              "use FixedUpdate for more accurate velocity and acceleration measurements.")]
        
        [OwnerDefaultValue]
        [Tooltip("Transform to track.")]
        [SerializeField] private TransformVar _transform;

        [ActionHeader("Settings")]
        [Tooltip("Speed below which the object is considered idle (units/s).")]
        [SerializeField, DefaultValue(0.01f)] private FloatVar _speedThreshold;

        [Tooltip("If a single step exceeds this distance, treat it as a teleport (excluded from path/velocity). 0 = disabled.")]
        [SerializeField, DefaultValue(0f)] private FloatVar _teleportStepThreshold;

        
        // ─────────────────────────────────────────────────────────────────────────
        // Outputs — Instant & Averages
        // ─────────────────────────────────────────────────────────────────────────

        [ActionHeader("Instant & Averages")]
        [Tooltip("Velocity over the last frame (world units / second).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _velocityLastFrame;

        [Tooltip("Average velocity since entering the state (world units / second).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _averageVelocity;

        [Tooltip("Average speed (path length / time tracked).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _averageSpeed;

        // ─────────────────────────────────────────────────────────────────────────
        // Outputs — Distance & Area
        // ─────────────────────────────────────────────────────────────────────────

        [ActionHeader("Distance & Area")]
        [Tooltip("Total change in position since entering the state (displacement).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _totalDelta;

        [Tooltip("Total path length traveled (accumulated distance).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _pathLength;

        [Tooltip("Average position since entering the state (world space).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _averagePosition;

        [Tooltip("Bounds of the world position over the lifetime of the state.")]
        [SerializeField, WriteOnly, OptionalField] private BoundsRef _bounds;

        // ─────────────────────────────────────────────────────────────────────────
        // Outputs — Timing
        // ─────────────────────────────────────────────────────────────────────────

        [ActionHeader("Timing")]
        [Tooltip("Time spent moving (speed >= Speed Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _movingTime;

        [Tooltip("Time spent idle (speed < Speed Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _idleTime;

        [Tooltip("Number of times movement stopped (moving → idle).")]
        [SerializeField, WriteOnly, OptionalField] private IntegerRef _stopCount;

        // ─────────────────────────────────────────────────────────────────────────
        // Outputs — Peaks & Events
        // ─────────────────────────────────────────────────────────────────────────

        [ActionHeader("Peaks & Events")]
        [Tooltip("Peak speed since entering the state.")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _maxSpeed;

        [Tooltip("Velocity vector when peak speed occurred.")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _maxVelocity;

        [Tooltip("Horizontal peak speed (ignores Y).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _maxHorizontalSpeed;

        [Tooltip("Peak acceleration magnitude (units/s²).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _maxAcceleration;

        [Tooltip("Number of teleports detected (step > Teleport Step Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private IntegerRef _teleportCount;

        // ─────────────────────────────────────────────────────────────────────────
        // Internal state
        // ─────────────────────────────────────────────────────────────────────────

        private Vector3 _initialPosition;   // position on enter
        private Vector3 _lastPosition;      // previous frame position
        private int _frameCount;            // sample count
        private float _timeAccum;           // sum of dt
        private Vector3 _positionAccum;     // sum of positions
        private Bounds _trackedBounds;      // running bounds

        // Peaks / timing
        private float _maxSpeedVal;
        private Vector3 _maxVelocityVal;
        private float _maxAccelVal;
        private float _pathLen;
        private float _movingT;
        private float _idleT;
        private bool _wasMoving;
        private int _stopCountVal;
        private float _maxHorizSpeedVal;
        private int _teleports;
        private Vector3 _lastVelocity;      // for accel
        private bool _hasLastVelocity;
        private float _velocitySampleElapsed;
        private Rigidbody _rigidbody;
        private Rigidbody2D _rigidbody2D;

        // Debug
#if UNITY_EDITOR
        public override bool HasDebugInfo => true;
        private float _lastSpeed;
#endif

        public override bool CanExecute() => CheckParameters(_transform);

        public override void OnStateEnter()
        {
            var t = _transform.Value;
            var start = t ? t.position : Vector3.zero;

            _initialPosition = start;
            _lastPosition = start;
            _frameCount = 0;
            _timeAccum = 0f;
            _positionAccum = Vector3.zero;
            _trackedBounds = new Bounds(start, Vector3.zero);

            _maxSpeedVal = 0f;
            _maxVelocityVal = Vector3.zero;
            _maxAccelVal = 0f;
            _pathLen = 0f;
            _movingT = 0f;
            _idleT = 0f;
            _wasMoving = false;
            _stopCountVal = 0;
            _maxHorizSpeedVal = 0f;
            _teleports = 0;
            _lastVelocity = Vector3.zero;
            _hasLastVelocity = false;
            _velocitySampleElapsed = 0f;
            _rigidbody = t ? t.GetComponent<Rigidbody>() : null;
            _rigidbody2D = t ? t.GetComponent<Rigidbody2D>() : null;

            if (_rigidbody && !_rigidbody.isKinematic)
            {
                _lastVelocity = _rigidbody.GetVelocityShim();
                _hasLastVelocity = true;
            }
            else if (_rigidbody2D && _rigidbody2D.bodyType != RigidbodyType2D.Kinematic)
            {
                var rb2dVelocity = _rigidbody2D.GetVelocityShim();
                _lastVelocity = new Vector3(rb2dVelocity.x, rb2dVelocity.y, 0f);
                _hasLastVelocity = true;
            }

#if UNITY_EDITOR
            _lastSpeed = 0f;
#endif
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            var hasValidDt = dt >= MinSampleDeltaTime;
            var current = t.position;

            // Samples / accumulators
            ++_frameCount;
            if (hasValidDt) _timeAccum += dt;
            _positionAccum += current;
            _trackedBounds.Encapsulate(current);

            // Step / teleport detection
            var step = current - _lastPosition;
            var dist = step.magnitude;
            var teleportThresh = _teleportStepThreshold.Value;
            var isTeleport = teleportThresh > 0f && dist > teleportThresh;
            var useRigidbodyVelocity = (_rigidbody && !_rigidbody.isKinematic) ||
                                       (_rigidbody2D && _rigidbody2D.bodyType != RigidbodyType2D.Kinematic);

            Vector3 velLast = Vector3.zero;
            if (!isTeleport)
            {
                _pathLen += dist;
                if (hasValidDt) _velocitySampleElapsed += dt;

                if (useRigidbodyVelocity)
                {
                    velLast = _rigidbody && !_rigidbody.isKinematic
                        ? _rigidbody.GetVelocityShim()
                        : new Vector3(_rigidbody2D.GetVelocityShim().x, _rigidbody2D.GetVelocityShim().y, 0f);

                    if (_velocityLastFrame.IsAssigned) _velocityLastFrame.Value = velLast;
                }
                else if (hasValidDt && dist > Mathf.Epsilon)
                {
                    velLast = step / _velocitySampleElapsed;
                    if (_velocityLastFrame.IsAssigned) _velocityLastFrame.Value = velLast;
                }
                else if (_velocityLastFrame.IsAssigned)
                {
                    _velocityLastFrame.Value = Vector3.zero;
                }

                var speed = velLast.magnitude;
                if (speed > _maxSpeedVal)
                {
                    _maxSpeedVal = speed;
                    _maxVelocityVal = velLast;
                }

                var horizSpeed = new Vector2(velLast.x, velLast.z).magnitude;
                if (horizSpeed > _maxHorizSpeedVal) _maxHorizSpeedVal = horizSpeed;

                var velocityChanged = (velLast - _lastVelocity).sqrMagnitude > Mathf.Epsilon * Mathf.Epsilon;
                if (_hasLastVelocity && hasValidDt && _velocitySampleElapsed > 0f && velocityChanged)
                {
                    var accel = (velLast - _lastVelocity) / _velocitySampleElapsed;
                    var accelMag = accel.magnitude;
                    if (accelMag > _maxAccelVal) _maxAccelVal = accelMag;
                }

                if (hasValidDt && (useRigidbodyVelocity || dist > Mathf.Epsilon))
                {
                    if (!_hasLastVelocity || velocityChanged)
                    {
                        _lastVelocity = velLast;
                        _hasLastVelocity = true;
                        _velocitySampleElapsed = 0f;
                    }
                }

                if (hasValidDt)
                {
                    var moving = speed >= _speedThreshold.Value;
                    if (moving) _movingT += dt; else _idleT += dt;
                    if (_wasMoving && !moving) _stopCountVal++;
                    _wasMoving = moving;
                }

#if UNITY_EDITOR
                _lastSpeed = speed;
#endif
            }
            else
            {
                _teleports++;
                _lastVelocity = Vector3.zero;
                _hasLastVelocity = false;
                _velocitySampleElapsed = 0f;
                if (_velocityLastFrame.IsAssigned) _velocityLastFrame.Value = Vector3.zero;
#if UNITY_EDITOR
                _lastSpeed = 0f;
#endif
            }

            // Averages & aggregates
            var totalDelta = current - _initialPosition;
            var avgVel = (_timeAccum > 0f) ? totalDelta / _timeAccum : Vector3.zero;
            var avgPos = (_frameCount > 0) ? _positionAccum / _frameCount : current;
            var avgSpeed = (_timeAccum > 0f) ? _pathLen / _timeAccum : 0f;

            // Write outputs if requested
            if (_averageVelocity.IsAssigned) _averageVelocity.Value = avgVel;
            if (_totalDelta.IsAssigned) _totalDelta.Value = totalDelta;
            if (_averagePosition.IsAssigned) _averagePosition.Value = avgPos;
            if (_bounds.IsAssigned) _bounds.Value = _trackedBounds;
            if (_pathLength.IsAssigned) _pathLength.Value = _pathLen;
            if (_averageSpeed.IsAssigned) _averageSpeed.Value = avgSpeed;

            if (_movingTime.IsAssigned) _movingTime.Value = _movingT;
            if (_idleTime.IsAssigned) _idleTime.Value = _idleT;
            if (_stopCount.IsAssigned) _stopCount.Value = _stopCountVal;

            if (_maxSpeed.IsAssigned) _maxSpeed.Value = _maxSpeedVal;
            if (_maxVelocity.IsAssigned) _maxVelocity.Value = _maxVelocityVal;
            if (_maxHorizontalSpeed.IsAssigned) _maxHorizontalSpeed.Value = _maxHorizSpeedVal;
            if (_maxAcceleration.IsAssigned) _maxAcceleration.Value = _maxAccelVal;
            if (_teleportCount.IsAssigned) _teleportCount.Value = _teleports;

            // Carry forward
            _lastPosition = current;
        }

        public override string GetSummary() =>
            "Track {_transform} " +
            "{_velocityLastFrame:output} {_averageVelocity:output} {_averageSpeed:output} " +
            "{_totalDelta:output} {_pathLength:output} {_averagePosition:output} {_bounds:output} " +
            "{_movingTime:output} {_idleTime:output} {_stopCount:output} " +
            "{_maxSpeed:output} {_maxVelocity:output} {_maxHorizontalSpeed:output} {_maxAcceleration:output} {_teleportCount:output}";

#if UNITY_EDITOR
        public override string GetDebugInfo()
        {
            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            return $"dt:{dt:0.000} speed:{_lastSpeed:0.###} path:{_pathLen:0.##} teleports:{_teleports}";
        }
#endif
    }
}
