
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Rotates the Transform about an axis passing through point in world coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html")]
	public sealed class TransformRotateAround : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Point.")]
		[SerializeField]
		private Vector3Var _point;
		
		[Tooltip("Axis.")]
		[SerializeField]
		private Vector3Var _axis;
		
		[Tooltip("Angle.")]
		[SerializeField]
		private FloatVar _angle;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_transform, _point, _axis, _angle);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.RotateAround(_point.Value, _axis.Value, _angle.Value * PerSecond);
		}

		public override string GetSummary() => 
			"Rotate {_transform} around {_point} on axis {_axis} by {_angle} {PerSecond}";
	}
}
