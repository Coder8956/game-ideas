
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Sets the position and rotation of the Transform component in local space (i.e. re" +
		"lative to its parent transform).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetLocalPositionAndRotation.ht" +
		"ml")]
	public sealed class TransformSetLocalPositionAndRotation : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Local Position.")]
		[SerializeField]
		private Vector3Var _localPosition;
		
		[Tooltip("Local Rotation.")]
		[SerializeField]
		private QuaternionVar _localRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _localPosition, _localRotation);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.SetLocalPositionAndRotation(_localPosition.Value, _localRotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Local Position And Rotation {_transform} {_localPosition} {_localRotation} ";
		}
	}
}
