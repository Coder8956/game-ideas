
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Rotates the object around the given axis by the number of degrees defined by the " +
		"given angle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Rotate.html")]
	public sealed class TransformRotate__AxisAngle : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The axis to apply rotation to.")]
		[SerializeField]
		private Vector3Var _axis;
		
		[Tooltip("The degrees of rotation to apply." + Strings.PerSecondNote)]
		[SerializeField]
		private FloatVar _angle;
		
		[Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
		         "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_transform, _axis, _angle, _relativeTo);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.Rotate(_axis.Value, _angle.Value * PerSecond, _relativeTo.Value);
		}

		public override string GetSummary() => 
			"Rotate {_transform} {_axis} {_angle} {_relativeTo} {PerSecond}";
	}
}
