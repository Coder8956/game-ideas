using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ActionDescription("Track a transform's rotation over time and provide useful stats. " +
                       "Starts tracking when the state is entered and stops when the state is exited.")]
    [HelpURL("actions/transform-actions/tracking-actions/")]
    public sealed class TransformTrackRotation : BaseAction
    {
        private const float MinSampleDeltaTime = 0.0001f;

        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue]
        [Tooltip("Transform to track.")]
        [SerializeField] private TransformVar _transform;

        [ActionHeader("Settings")]
        [Tooltip("Track rotation in world space or local space.")]
        [SerializeField] private SpaceVar _inSpace;

        [Tooltip("Angular speed below which the object is considered idle (degrees/s).")]
        [SerializeField, DefaultValue(1f)] private FloatVar _angularSpeedThreshold;

        [Tooltip("If a single step exceeds this angle, treat it as a teleport (excluded from path/velocity). 0 = disabled.")]
        [SerializeField, DefaultValue(0f)] private FloatVar _teleportStepThreshold;

        [ActionHeader("Instant & Averages")]
        [Tooltip("Signed Euler angle delta over the last frame (degrees).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _deltaEulerLastFrame;

        [Tooltip("Angular velocity over the last frame (degrees / second).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _angularVelocityLastFrame;

        [Tooltip("Average signed angular velocity since entering the state (degrees / second).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _averageAngularVelocity;

        [Tooltip("Average angular speed since entering the state (degrees / second).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _averageAngularSpeed;

        [ActionHeader("Rotation")]
        [Tooltip("Signed accumulated Euler rotation since entering the state (degrees). Useful for tracking total yaw/pitch/roll over time.")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _totalDeltaEuler;

        [Tooltip("Accumulated absolute Euler rotation distance per axis since entering the state (degrees). Opposite directions do not cancel out.")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _totalEulerDistances;

        [Tooltip("Current signed Euler delta from the initial rotation (degrees).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _deltaFromStartEuler;

        [Tooltip("Current shortest angular distance from the initial rotation (degrees).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _angleFromStart;

        [Tooltip("Total angular path length traveled (degrees).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _rotationPathLength;

        [ActionHeader("Timing")]
        [Tooltip("Time spent rotating (angular speed >= Angular Speed Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _rotatingTime;

        [Tooltip("Time spent idle (angular speed < Angular Speed Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _idleTime;

        [Tooltip("Number of times rotation stopped (rotating -> idle).")]
        [SerializeField, WriteOnly, OptionalField] private IntegerRef _stopCount;

        [ActionHeader("Peaks & Events")]
        [Tooltip("Peak angular speed since entering the state (degrees / second).")]
        [SerializeField, WriteOnly, OptionalField] private FloatRef _maxAngularSpeed;

        [Tooltip("Angular velocity vector when peak angular speed occurred (degrees / second).")]
        [SerializeField, WriteOnly, OptionalField] private Vector3Ref _maxAngularVelocity;

        [Tooltip("Number of teleports detected (step > Teleport Step Threshold).")]
        [SerializeField, WriteOnly, OptionalField] private IntegerRef _teleportCount;

        private Quaternion _initialRotation;
        private Vector3 _initialEuler;
        private Quaternion _lastRotation;
        private Vector3 _lastEuler;
        private float _timeAccum;
        private Vector3 _totalDeltaEulerAccum;
        private Vector3 _totalEulerDistancesAccum;
        private float _rotationPathLen;
        private float _rotatingT;
        private float _idleT;
        private bool _wasRotating;
        private int _stopCountVal;
        private float _maxAngularSpeedVal;
        private Vector3 _maxAngularVelocityVal;
        private int _teleports;

#if UNITY_EDITOR
        public override bool HasDebugInfo => true;
        private float _lastAngularSpeed;
        private float _debugAngularSpeed;
#endif

        public override bool CanExecute() => CheckParameters(_transform, _inSpace);

        public override void OnStateEnter()
        {
            var t = _transform.Value;
            var start = t ? GetRotation(t) : Quaternion.identity;

            _initialRotation = start;
            _initialEuler = start.eulerAngles;
            _lastRotation = start;
            _lastEuler = _initialEuler;
            _timeAccum = 0f;
            _totalDeltaEulerAccum = Vector3.zero;
            _totalEulerDistancesAccum = Vector3.zero;
            _rotationPathLen = 0f;
            _rotatingT = 0f;
            _idleT = 0f;
            _wasRotating = false;
            _stopCountVal = 0;
            _maxAngularSpeedVal = 0f;
            _maxAngularVelocityVal = Vector3.zero;
            _teleports = 0;

#if UNITY_EDITOR
            _lastAngularSpeed = 0f;
            _debugAngularSpeed = 0f;
#endif
        }

        public override void Execute()
        {
            var t = _transform.Value;
            if (!t) return;

            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            var hasValidDt = dt >= MinSampleDeltaTime;

            var currentRotation = GetRotation(t);
            var currentEuler = currentRotation.eulerAngles;
            var deltaEuler = GetDeltaEuler(_lastEuler, currentEuler);
            var stepAngle = Quaternion.Angle(_lastRotation, currentRotation);
            var teleportThresh = _teleportStepThreshold.Value;
            var isTeleport = teleportThresh > 0f && stepAngle > teleportThresh;

            if (!isTeleport)
            {
                _totalDeltaEulerAccum += deltaEuler;
                _totalEulerDistancesAccum += new Vector3(
                    Mathf.Abs(deltaEuler.x),
                    Mathf.Abs(deltaEuler.y),
                    Mathf.Abs(deltaEuler.z));
                _rotationPathLen += stepAngle;

                if (_deltaEulerLastFrame.IsAssigned) _deltaEulerLastFrame.Value = deltaEuler;

                Vector3 angularVelocity = Vector3.zero;
                var angularSpeed = 0f;
                if (hasValidDt)
                {
                    angularVelocity = deltaEuler / dt;
                    angularSpeed = stepAngle / dt;
                }

                if (_angularVelocityLastFrame.IsAssigned) _angularVelocityLastFrame.Value = angularVelocity;

                if (angularSpeed > _maxAngularSpeedVal)
                {
                    _maxAngularSpeedVal = angularSpeed;
                    _maxAngularVelocityVal = angularVelocity;
                }

                if (hasValidDt)
                {
                    _timeAccum += dt;

                    var rotating = angularSpeed >= _angularSpeedThreshold.Value;
                    if (rotating) _rotatingT += dt;
                    else _idleT += dt;

                    if (_wasRotating && !rotating) _stopCountVal++;
                    _wasRotating = rotating;
                }

#if UNITY_EDITOR
                _lastAngularSpeed = angularSpeed;
                _debugAngularSpeed = Mathf.Lerp(_debugAngularSpeed, angularSpeed, 0.2f);
#endif
            }
            else
            {
                _teleports++;
                if (_deltaEulerLastFrame.IsAssigned) _deltaEulerLastFrame.Value = Vector3.zero;
                if (_angularVelocityLastFrame.IsAssigned) _angularVelocityLastFrame.Value = Vector3.zero;

#if UNITY_EDITOR
                _lastAngularSpeed = 0f;
                _debugAngularSpeed = Mathf.Lerp(_debugAngularSpeed, 0f, 0.2f);
#endif
            }

            var deltaFromStartEuler = GetDeltaEuler(_initialEuler, currentEuler);
            var averageAngularVelocity = _timeAccum > 0f ? _totalDeltaEulerAccum / _timeAccum : Vector3.zero;
            var averageAngularSpeed = _timeAccum > 0f ? _rotationPathLen / _timeAccum : 0f;
            var angleFromStart = Quaternion.Angle(_initialRotation, currentRotation);

            if (_averageAngularVelocity.IsAssigned) _averageAngularVelocity.Value = averageAngularVelocity;
            if (_averageAngularSpeed.IsAssigned) _averageAngularSpeed.Value = averageAngularSpeed;
            if (_totalDeltaEuler.IsAssigned) _totalDeltaEuler.Value = _totalDeltaEulerAccum;
            if (_totalEulerDistances.IsAssigned) _totalEulerDistances.Value = _totalEulerDistancesAccum;
            if (_deltaFromStartEuler.IsAssigned) _deltaFromStartEuler.Value = deltaFromStartEuler;
            if (_angleFromStart.IsAssigned) _angleFromStart.Value = angleFromStart;
            if (_rotationPathLength.IsAssigned) _rotationPathLength.Value = _rotationPathLen;

            if (_rotatingTime.IsAssigned) _rotatingTime.Value = _rotatingT;
            if (_idleTime.IsAssigned) _idleTime.Value = _idleT;
            if (_stopCount.IsAssigned) _stopCount.Value = _stopCountVal;

            if (_maxAngularSpeed.IsAssigned) _maxAngularSpeed.Value = _maxAngularSpeedVal;
            if (_maxAngularVelocity.IsAssigned) _maxAngularVelocity.Value = _maxAngularVelocityVal;
            if (_teleportCount.IsAssigned) _teleportCount.Value = _teleports;

            _lastRotation = currentRotation;
            _lastEuler = currentEuler;
        }

        public override string GetSummary() =>
            "Track {_transform} rotation ({_inSpace}) " +
            "{_deltaEulerLastFrame:output} {_angularVelocityLastFrame:output} {_averageAngularVelocity:output} {_averageAngularSpeed:output} " +
            "{_totalDeltaEuler:output} {_totalEulerDistances:output} {_deltaFromStartEuler:output} {_angleFromStart:output} {_rotationPathLength:output} " +
            "{_rotatingTime:output} {_idleTime:output} {_stopCount:output} " +
            "{_maxAngularSpeed:output} {_maxAngularVelocity:output} {_teleportCount:output}";

#if UNITY_EDITOR
        public override string GetDebugInfo()
        {
            var dt = DeltaTime > 0f ? DeltaTime : Time.deltaTime;
            return $"dt:{dt,8:0.000} angSpeed:{_debugAngularSpeed,+9:0.0;-9:0.0; 0.0} path:{_rotationPathLen,9:0.00} teleports:{_teleports,4}";
        }
#endif

        private Quaternion GetRotation(Transform t) =>
            _inSpace.Value == Space.World ? t.rotation : t.localRotation;

        private static Vector3 GetDeltaEuler(Vector3 fromEuler, Vector3 toEuler)
        {
            return new Vector3(
                Mathf.DeltaAngle(fromEuler.x, toEuler.x),
                Mathf.DeltaAngle(fromEuler.y, toEuler.y),
                Mathf.DeltaAngle(fromEuler.z, toEuler.z));
        }
    }
}
