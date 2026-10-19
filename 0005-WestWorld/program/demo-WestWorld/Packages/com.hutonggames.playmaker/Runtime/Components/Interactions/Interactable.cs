using UnityEngine;

namespace HutongGames.PlayMaker
{
    [AddComponentMenu("PlayMaker/Interactable")]
    [HelpURL("https://hutonggames.com/playmaker/docs/components/interactable/")]
    [Icon("Packages/com.hutonggames.playmaker/Editor/Resources/playmakerIconSmall.png")]
    public sealed class Interactable : MonoBehaviour
    {
        public enum MeasurementSpace
        {
            World,
            ReferenceTransform
        }

        public enum DistanceFromMode
        {
            Transform,
            Collider
        }

        public enum PositionConstraintMode
        {
            Radial,
            Box
        }

        public enum AuthoredDirectionAxis
        {
            Forward,
            Right,
            Up
        }

        public enum DockingPolicy
        {
            None,
            Dock
        }

        [Tooltip("User-defined interaction name such as Climb, Vehicle, Seat, or ATM. Actions can read this and branch based on the value.")]
        [SerializeField]
        private string _interaction = "Generic";

        [Tooltip("Optional GameObject that receives interaction events and tag checks. Uses this Interactable's GameObject when left empty.")]
        [SerializeField]
        private GameObject _targetGameObject;

        [Tooltip("Whether this interactable can currently be selected and activated by Interactors.")]
        [SerializeField]
        private bool _isEnabled = true;

        [Tooltip("Used for radial distance, approach, and facing projection. Box mode uses explicit per-axis limits for positional filtering.")]
        [SerializeField]
        private MoveAxis _measurementAxis = MoveAxis.XYZ;

        [Tooltip("Whether the measurement axis is evaluated in world space or relative to the reference transform.")]
        [SerializeField]
        private MeasurementSpace _measurementSpace = MeasurementSpace.World;

        [Tooltip("Where the position used for distance checks comes from." +
                 "\nTransform is best for compact objects. " +
                 "\nCollider is best for ladders and other extended volumes.")]
        [SerializeField]
        private DistanceFromMode _distanceMode = DistanceFromMode.Transform;

        [Tooltip("How positional validity is tested. Radial uses projected distance with Measurement Axis. Box uses per-axis deltas in the selected Measurement Space.")]
        [SerializeField]
        private PositionConstraintMode _positionConstraintMode = PositionConstraintMode.Radial;

        [Tooltip("Minimum recommended interaction distance from this transform when Position Constraint Mode is Radial. Values of 0 or less disable the local limit.")]
        [SerializeField]
        private float _minInteractionDistance;

        [Tooltip("Maximum recommended interaction distance from this transform when Position Constraint Mode is Radial. Values of 0 or less disable the local limit.")]
        [SerializeField]
        private float _maxInteractionDistance = 1.5f;

        [Tooltip("Maximum allowed per-axis delta from this transform when Position Constraint Mode is Box. Values of 0 or less ignore that axis.")]
        [SerializeField]
        private Vector3 _maxPositionDelta = new(2,2,2);

        [Tooltip("Optional trigger volume the actor collider must overlap for this interactable to become valid. Supported trigger types: BoxCollider, SphereCollider, and CapsuleCollider.")]
        [SerializeField]
        private Collider _insideTrigger;

        [Tooltip("Require the actor to stand on the authored side of the interaction.")]
        [SerializeField]
        private bool _requireApproach;

        [Tooltip("Maximum angle in degrees of the valid approach side. 0 is exact, 90 allows side-on approach.")]
        [SerializeField, Range(0f, 180f)]
        private float _maxApproachAngle = 60f;

        [Tooltip("Invert the authored approach direction. Enable this if the approach fan draws the wrong way for this object.")]
        [SerializeField]
        private bool _invertFacing;

        [Tooltip("The authored local axis used to define the approach and facing side. Forward is typical for 3D setups, while Right or Up are useful for side-view and top-down setups.")]
        [SerializeField]
        private AuthoredDirectionAxis _authoredDirectionAxis = AuthoredDirectionAxis.Forward;

        [Tooltip("Require the actor forward direction to point toward the interaction target.")]
        [SerializeField]
        private bool _requireFacing;

        [Tooltip("Allowed facing tolerance in degrees from exact look-at. 0 requires the actor to face the target exactly. Larger values allow more deviation.")]
        [SerializeField, Range(0f, 180f)]
        private float _maxFacingAngle = 45f;

        [Tooltip("Require the actor's forward ray to hit this interactable before it becomes valid.")]
        [SerializeField]
        private bool _requireRaycastHit;

        [Tooltip("Requires activation before this interaction can trigger. Example: a button or ATM usually needs activation, while a ladder or climb volume may not.")]
        [SerializeField]
        private bool _isExplicitInteraction;

        [Tooltip("Optional activation identifier for interactions that need activation, such as Use, AltUse, or SecondaryFire. Leave empty to accept any activation input.")]
        [SerializeField]
        private string _activationId;

        [Tooltip("Higher priority wins when multiple candidates are valid.")]
        [SerializeField]
        private int _priority;

        [Tooltip("Optional transform to use for docking/snap alignment. Uses this Interactable's transform when not assigned.")]
        [SerializeField]
        private Transform _dockingTransform;

        [Tooltip("Whether activation should apply this Interactable's docking settings.")]
        [SerializeField]
        private DockingPolicy _dockingPolicy = DockingPolicy.None;

        [Tooltip("Match the docking position when docking is applied.")]
        [SerializeField]
        private bool _dockPosition = true;

        [Tooltip("Constrain docking position to a line or plane using the docking transform axes. XYZ matches the full docking position.")]
        [SerializeField]
        private MoveAxis _dockPositionAxis = MoveAxis.XYZ;

        [Tooltip("Match the docking rotation when docking is applied.")]
        [SerializeField]
        private bool _dockRotation = true;

        [Tooltip("Optional transform to use for undocking/exit alignment.")]
        [SerializeField]
        private Transform _undockingTransform;

        public string Interaction => string.IsNullOrEmpty(_interaction) ? "Generic" : _interaction;
        public GameObject TargetGameObject => _targetGameObject ? _targetGameObject : gameObject;
        public Transform ReferenceTransform => transform;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => _isEnabled = value;
        }

        public PositionConstraintMode PositionDistanceMode => _positionConstraintMode;
        public MoveAxis MeasurementAxis => _measurementAxis;
        public MeasurementSpace InteractionMeasurementSpace => _measurementSpace;
        public DistanceFromMode DistanceFrom => _distanceMode;
        public float MinInteractionDistance => _minInteractionDistance;
        public float MaxInteractionDistance => _maxInteractionDistance;
        public Vector3 MaxPositionDelta => _maxPositionDelta;
        public Collider InsideTrigger => _insideTrigger;
        public bool RequireApproach => _requireApproach;
        public float MaxApproachAngle => _maxApproachAngle;
        public float MaxFacingAngle => _maxFacingAngle;
        public bool InvertFacing => _invertFacing;
        public AuthoredDirectionAxis DirectionAxis => _authoredDirectionAxis;
        public bool RequireFacing => _requireFacing;
        public bool RequireRaycastHit => _requireRaycastHit;
        public bool IsExplicitInteraction => _isExplicitInteraction;
        public string ActivationId => string.IsNullOrEmpty(_activationId) ? string.Empty : _activationId;
        public int Priority => _priority;
        public DockingPolicy DockingMode => _dockingPolicy;
        public bool ShouldDock => _dockingPolicy == DockingPolicy.Dock;
        public bool HasDockingTransform => _dockingTransform;
        public bool HasUndockingTransform => _undockingTransform;
        public Transform DockingTransform => _dockingTransform ? _dockingTransform : ReferenceTransform;
        public bool DockPosition => _dockPosition;
        public MoveAxis DockPositionAxis => _dockPositionAxis;
        public bool DockRotation => _dockRotation;
        public Transform UndockingTransform => _undockingTransform;

        public Vector3 ApproachNormal
        {
            get
            {
                var direction = GetDirectionAxisWorldVector();

                return _invertFacing ? -direction : direction;
            }
        }

        public Vector3 GetDirectionAxisWorldVector()
        {
            var referenceTransform = ReferenceTransform ? ReferenceTransform : transform;
            return _authoredDirectionAxis switch
            {
                AuthoredDirectionAxis.Right => referenceTransform.right,
                AuthoredDirectionAxis.Up => referenceTransform.up,
                _ => referenceTransform.forward
            };
        }

    }
}
