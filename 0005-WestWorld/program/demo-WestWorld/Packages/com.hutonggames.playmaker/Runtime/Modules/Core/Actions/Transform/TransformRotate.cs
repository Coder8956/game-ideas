
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	//[HasSceneGUI]
	[System.Serializable]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees " +
		"around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Rotate.html")]
	public sealed class TransformRotate : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		public Transform Transform => _transform.Value;
		public Vector3Var Eulers => _eulers;
		
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The rotation to apply in euler angles.")]
		[SerializeField]
		private Vector3Var _eulers;
		
		[Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
		         "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_transform, _eulers, _relativeTo);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.Rotate(_eulers.Value * PerSecond, _relativeTo.Value);
		}

		public override string GetSummary() => "Rotate {_transform} by {_eulers} in {_relativeTo} space {PerSecond}";
	}
}
