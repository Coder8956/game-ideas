using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Match a Transform's world position and rotation to a target Transform, with per-axis control.")]
	[HelpURL("actions/transform-actions/transform-value-actions/")]
	public sealed class TransformMatchTarget : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[OwnerDefaultValue]
		[Tooltip("The Transform to update.")]
		[SerializeField]
		private TransformVar _transform;

		[Tooltip("The target Transform to match.")]
		[SerializeField]
		private TransformVar _target;

		[ActionHeader("Position")]
		
		[DisplayName("X")]
		[Tooltip("Match world position X.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _positionX;

		[DisplayName("Y")]
		[Tooltip("Match world position Y.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _positionY;

		[DisplayName("Z")]
		[Tooltip("Match world position Z.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _positionZ;

		[ActionHeader("Rotation")]
		
		[DisplayName("X")]
		[Tooltip("Match world rotation X.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _rotationX;

		[DisplayName("Y")]
		[Tooltip("Match world rotation Y.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _rotationY;

		[DisplayName("Z")]
		[Tooltip("Match world rotation Z.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _rotationZ;

        public override bool CanStart() => CheckParameters(_transform, _target);

        public override bool CanExecute() => CheckParameters(_transform);
		
		public override void Execute()
		{
			var transform = _transform.Value;
			var target = _target.Value;

			if (transform == null) return;
            if (target == null)
            {
                Finish();
                return;
            }

			var position = transform.position;
			var targetPosition = target.position;

			if (_positionX.Value) position.x = targetPosition.x;
			if (_positionY.Value) position.y = targetPosition.y;
			if (_positionZ.Value) position.z = targetPosition.z;

			var eulerAngles = transform.eulerAngles;
			var targetEulerAngles = target.eulerAngles;

			if (_rotationX.Value) eulerAngles.x = targetEulerAngles.x;
			if (_rotationY.Value) eulerAngles.y = targetEulerAngles.y;
			if (_rotationZ.Value) eulerAngles.z = targetEulerAngles.z;

			transform.SetPositionAndRotation(position, Quaternion.Euler(eulerAngles));
		}

		public override string GetSummary()
		{
			return "Match {_transform} to {_target} " +
			       "Pos(X:{_positionX} Y:{_positionY} Z:{_positionZ}) " +
			       "Rot(X:{_rotationX} Y:{_rotationY} Z:{_rotationZ})";
		}
	}
}
