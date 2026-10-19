/*
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Pathfinding)]
    [ActionDescription("Follow a list of world-space waypoints using a Rigidbody2D or Transform.")]
    [HelpURL("actions/pathfinding/grid/follow-waypoints-2d/")]
    public sealed class FollowWaypoints2D : BaseAction
    {
        [Tooltip("Optional: Rigidbody2D to move. If null, moves the Transform directly.")]
        [SerializeField]
        private Rigidbody2DVar _rigidbody;

        [Tooltip("Transform to move if Rigidbody2D is not provided.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("Waypoints to follow (world positions).")]
        [SerializeField]
        private Vector2ListVar _waypoints;

        [Tooltip("Move speed in world units per second.")]
        [SerializeField, DefaultValue(3f)]
        private FloatVar _speed;

        [Tooltip("Distance to a waypoint to consider it reached.")]
        [SerializeField, DefaultValue(0.05f)]
        private FloatVar _arriveRadius;

        [Tooltip("Max seconds without progress before reporting Stuck (0 disables).")]
        [SerializeField, DefaultValue(1.0f)]
        private FloatVar _stuckTime;

        [ActionHeader("Output")]
        [Tooltip("True when all waypoints are reached.")]
        [SerializeField]
        private BoolVar _reached;

        [Tooltip("True when no waypoints provided.")]
        [SerializeField]
        private BoolVar _empty;

        [Tooltip("True if movement made no progress for StuckTime seconds.")]
        [SerializeField]
        private BoolVar _stuck;

        // runtime
        private int _index;
        private Vector2 _lastPos;
        private float _lastProgressT;

        public override bool CanExecute() => CheckParameters(_waypoints) && (CheckParameters(_rigidbody) || CheckParameters(_transform));

        public override void OnStart()
        {
            _index = 0;
            _reached.Value = false;
            _stuck.Value = false;

            var tr = GetTransform();
            _lastPos = tr != null ? (Vector2)tr.position : Vector2.zero;
            _lastProgressT = Time.time;

            if (_waypoints.Values == null || _waypoints.Values.Length == 0)
            {
                _empty.Value = true;
                Finish();
                return;
            }

            _empty.Value = false;
        }

        public override void Execute()
        {
            if (_empty.Value || _reached.Value || _stuck.Value)
                return;

            var tr = GetTransform();
            if (tr == null) { _stuck.Value = true; Finish(); return; }

            var wp = _waypoints.Values;
            if (_index >= wp.Length)
            {
                _reached.Value = true;
                Finish();
                return;
            }

            var pos = (Vector2)tr.position;
            var target = wp[_index];

            var to = target - pos;
            var dist = to.magnitude;

            // Arrive
            if (dist <= Mathf.Max(0.0001f, _arriveRadius.Value))
            {
                _index++;
                _lastProgressT = Time.time;
                if (_index >= wp.Length)
                {
                    _reached.Value = true;
                    Finish();
                }
                return;
            }

            // Move
            var step = to / Mathf.Max(dist, 0.0001f) * _speed.Value * Time.deltaTime;

            if (_rigidbody.Value != null)
                _rigidbody.Value.MovePosition(pos + step);
            else
                tr.position = (Vector3)(pos + step);

            // Stuck detection (no progress vs lastPos)
            if (_stuckTime.Value > 0f)
            {
                if ((pos - _lastPos).sqrMagnitude > 0.0001f)
                {
                    _lastPos = pos;
                    _lastProgressT = Time.time;
                }
                else if (Time.time - _lastProgressT >= _stuckTime.Value)
                {
                    _stuck.Value = true;
                    Finish();
                    return;
                }
            }
        }

        public override string GetSummary() => "Follow {_waypoints} at {_speed}/s";

        private Transform GetTransform()
        {
            if (_rigidbody.Value != null) return _rigidbody.Value.transform;
            return _transform.Value != null ? _transform.Value : null;
        }
    }
}
*/