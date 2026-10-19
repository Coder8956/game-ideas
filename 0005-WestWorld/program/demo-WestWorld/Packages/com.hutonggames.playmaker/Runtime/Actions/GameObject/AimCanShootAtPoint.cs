using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingAim)]
    [ActionDescription("Checks if a world-space aim point is within a firing cone and range. " +
                       "Optionally requires a clear line of sight (raycast) to the aim point.")]
    [HelpURL("actions/gameobject-actions/aim/aim-can-shoot-at-point/")]
    public sealed class AimCanShootAtPoint : BaseAction
    {
        private const float MinDistance = 1e-6f;

        [Tooltip("Shooter transform (or GameObject). Uses its forward direction as the aim direction.")]
        [SerializeField]
        private GameObjectVar _shooter;

        [Tooltip("World-space point to aim/shoot at.")]
        [SerializeField]
        private Vector3Var _aimPoint;

        [ActionHeader("Weapon")]
        [Tooltip("Maximum range to allow shooting (meters). Set 0 for unlimited.")]
        [SerializeField]
        private FloatVar _maxRange;

        [Tooltip("Firing cone half-angle (degrees). Smaller values require tighter aim.")]
        [SerializeField]
        private FloatVar _fireConeDeg;

        [ActionHeader("Shooter")]
        [Tooltip("Optional offset/position to use as the shot origin (e.g., muzzle position).")]
        [SerializeField, OptionalField, FormerlySerializedAs("_shooterLocalOffset")]
        private Vector3Ref _shooterOffset;

        [Tooltip("<b>Self</b>: Shooter Offset is local to the shooter transform." +
                 "<br/><b>World</b>: Shooter Offset is already a world-space position.")]
        [SerializeField, DefaultValue(Space.Self)]
        private SpaceVar _shooterOffsetSpace = new() { Value = Space.Self };

        [ActionHeader("Line Of Sight (Optional)")]
        [Tooltip("If true, raycasts to the aim point and only allows shooting if nothing blocks the shot.")]
        [SerializeField]
        private BoolVar _requireLineOfSight;

        [Tooltip("Layer mask used for line of sight raycasts. Only these layers can block the shot.")]
        [SerializeField]
        private LayerMaskVar _obstacleLayers;

        [Tooltip("If true, trigger colliders are ignored by the line of sight raycast.")]
        [SerializeField]
        private BoolVar _ignoreTriggers;

        [Tooltip("Draw the line of sight ray in the Scene view for debugging.")]
        [SerializeField]
        private BoolVar _drawLineOfSightDebug = new();

        [Tooltip("Debug color when the line of sight is clear.")]
        [SerializeField, DefaultValue("Color.green")]
        private ColorVar _lineOfSightClearColor = new() { Value = Color.green };

        [Tooltip("Debug color when the line of sight is blocked.")]
        [SerializeField, DefaultValue("Color.red")]
        private ColorVar _lineOfSightBlockedColor = new() { Value = Color.red };

        [ActionHeader("Store")]
        [SerializeField, OptionalField, WriteOnly]
        [Tooltip("Store true if the aim point is within the firing cone, within range, and (optionally) visible.")]
        private BoolRef _storeCanShoot;

        [SerializeField, OptionalField, WriteOnly]
        [Tooltip("Store the aim angle to the aim point (degrees).")]
        private FloatRef _storeAimAngleDeg;

        [SerializeField, OptionalField, WriteOnly]
        [Tooltip("Store distance to the aim point (meters).")]
        private FloatRef _storeDistance;

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        public override bool CanExecute() =>
            CheckParameters(_shooter, _aimPoint, _maxRange, _fireConeDeg, _shooterOffsetSpace,
                            _requireLineOfSight, _obstacleLayers, _ignoreTriggers,
                            _drawLineOfSightDebug, _lineOfSightClearColor, _lineOfSightBlockedColor);

        public override void Execute()
        {
            var shooterGo = _shooter.Value;
            if (!shooterGo)
            {
                Store(false, 0f, 0f);
                return;
            }

            Transform shooterT = shooterGo.transform;

            Vector3 shooterPos = GetShooterPosition(shooterT);

            Vector3 toAim = _aimPoint.Value - shooterPos;
            float dist = toAim.magnitude;

            if (_storeDistance.IsAssigned) _storeDistance.Value = dist;

            // Range
            float maxRange = _maxRange.Value;
            if (maxRange > 0f && dist > maxRange)
            {
                float ang = (dist > MinDistance) ? Vector3.Angle(shooterT.forward, toAim / dist) : 0f;
                Store(false, ang, dist);
                return;
            }

            if (dist <= MinDistance)
            {
                Store(true, 0f, dist);
                return;
            }

            // Cone
            Vector3 aimDir = toAim / dist;
            float angleDeg = Vector3.Angle(shooterT.forward, aimDir);
            float cone = Mathf.Max(0f, _fireConeDeg.Value);

            if (angleDeg > cone)
            {
                Store(false, angleDeg, dist);
                return;
            }

            // Optional LOS
            if (_requireLineOfSight.Value)
            {
                int mask = _obstacleLayers.Value;
                QueryTriggerInteraction qti = _ignoreTriggers.Value
                    ? QueryTriggerInteraction.Ignore
                    : QueryTriggerInteraction.Collide;

                // Raycast only as far as the aim point (or maxRange if you prefer, but dist is usually correct).
                bool blocked = Physics.Raycast(shooterPos, aimDir, out RaycastHit hit, dist, mask, qti);
                DrawLineOfSightDebug(shooterPos, aimDir, dist, blocked, hit);

                if (blocked)
                {
                    // Something blocks the path to the aim point
                    Store(false, angleDeg, dist);
                    return;
                }
            }

            Store(true, angleDeg, dist);
        }

        private Vector3 GetShooterPosition(Transform shooterT)
        {
            if (!_shooterOffset.IsAssigned)
            {
                return shooterT.position;
            }

            return _shooterOffsetSpace.Value == Space.World
                ? _shooterOffset.Value
                : shooterT.TransformPoint(_shooterOffset.Value);
        }

        private void DrawLineOfSightDebug(Vector3 origin, Vector3 direction, float distance, bool blocked, RaycastHit hit)
        {
            if (!_drawLineOfSightDebug.Value)
            {
                return;
            }

            if (blocked)
            {
                Debug.DrawLine(origin, hit.point, _lineOfSightClearColor.Value);
                Debug.DrawLine(hit.point, origin + direction * distance, _lineOfSightBlockedColor.Value);
                return;
            }

            Debug.DrawLine(origin, origin + direction * distance, _lineOfSightClearColor.Value);
        }

        private void Store(bool canShoot, float angleDeg, float dist)
        {
            if (_storeCanShoot.IsAssigned) _storeCanShoot.Value = canShoot;
            if (_storeAimAngleDeg.IsAssigned) _storeAimAngleDeg.Value = angleDeg;
            if (_storeDistance.IsAssigned) _storeDistance.Value = dist;
        }

        public override string GetSummary() =>
            "{_shooter} can shoot at {_aimPoint} cone:{_fireConeDeg} range:{_maxRange} {_requireLineOfSight:option}";

#if UNITY_EDITOR
        public override bool HasGizmos => true;

        public override void OnDrawGizmosSelected()
        {
            if (!_drawLineOfSightDebug.Value)
            {
                return;
            }

            var shooterGo = _shooter.Value;
            if (!shooterGo)
            {
                return;
            }

            Vector3 origin = GetShooterPosition(shooterGo.transform);
            Vector3 toAim = _aimPoint.Value - origin;
            float distance = toAim.magnitude;

            if (distance <= MinDistance)
            {
                return;
            }

            Vector3 direction = toAim / distance;
            bool blocked = false;
            RaycastHit hit = default;

            if (_requireLineOfSight.Value)
            {
                QueryTriggerInteraction qti = _ignoreTriggers.Value
                    ? QueryTriggerInteraction.Ignore
                    : QueryTriggerInteraction.Collide;

                blocked = Physics.Raycast(origin, direction, out hit, distance, _obstacleLayers.Value, qti);
            }

            Gizmos.color = _lineOfSightClearColor.Value;
            Gizmos.DrawLine(origin, blocked ? hit.point : origin + direction * distance);
            Gizmos.DrawWireSphere(origin, 0.05f);

            if (blocked)
            {
                Gizmos.color = _lineOfSightBlockedColor.Value;
                Gizmos.DrawLine(hit.point, origin + direction * distance);
                Gizmos.DrawWireSphere(hit.point, 0.075f);
            }
        }
#endif
    }
}
