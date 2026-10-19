
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[HasSceneGUI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Align a Transform to the specified Direction. Optionally smooths the rotation with Smooth Time and Max Speed.")]
	[HelpURL("actions/transform-actions/look-at-actions/")]
	public sealed class TransformAlignToDirection : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform to align.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Axis to align to direction.")]
		[SerializeField]
		private AxisDirectionVar _alignAxis;
		
		[Tooltip("Direction to align to.")]
		[SerializeField, DefaultValue("Vector3.right")]
		private Vector3Var _direction;

		[Tooltip("Only use the direction vector if its length is greater than this value. " +
		         "Use this to avoid aligning to zero vectors.")]
		[SerializeField, DefaultValue(0.01f)]
		private FloatVar _minLength;

		[ActionHeader("Motion")]
		[VarSlider(0.0f, 1.0f)]
		[Tooltip("Smooth Time in seconds (roughly time to halve the remaining angle). 0 = no smoothing.")]
		[SerializeField, DefaultValue(0f)]
		private FloatVar _smoothTime;

		[VarSlider(0, 1080)]
		[Tooltip("Maximum turn speed in degrees per second. 0 = uncapped.")]
		[SerializeField, DefaultValue(0f)]
		private FloatVar _maxSpeed;
		
		public override bool CanExecute() => CheckParameters(_transform, _direction, _alignAxis, _minLength);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var minLength = _minLength.Value;
			if (_direction.Value.sqrMagnitude < minLength * minLength) return;
			
			var fromDirection = _alignAxis.Value.GetDirection(transform);
			var targetRotation = Quaternion.FromToRotation(fromDirection, _direction.Value) * transform.rotation;
			var smoothTime = SmoothTime;
			var maxSpeed = MaxSpeed;
			transform.rotation = smoothTime <= 0f && maxSpeed <= 0f
				? targetRotation
				: SmoothLookAtHelper.Update(transform.rotation, targetRotation, smoothTime, maxSpeed);
		}

		public override string GetSummary()
		{
			var s = "Align {_transform} {_alignAxis} to {_direction}";

			if (_smoothTime != null && _smoothTime.IsNotDefault())
				s += " in {_smoothTime}s";

			if (_maxSpeed != null && _maxSpeed.IsNotDefault())
				s += " max {_maxSpeed} deg/s";

			return s;
		}

		private float SmoothTime => _smoothTime?.Value ?? 0f;
		private float MaxSpeed => _maxSpeed?.Value ?? 0f;
		
		// For Scene GUI
		
		public Transform Transform => _transform.Value;
		public AxisDirection AlignAxis => _alignAxis.Value;
		public Vector3Var Direction => _direction; 
	}
}
