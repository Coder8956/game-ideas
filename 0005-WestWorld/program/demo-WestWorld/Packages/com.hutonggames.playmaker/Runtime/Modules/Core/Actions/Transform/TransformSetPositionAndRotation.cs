
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the world space position and rotation of the Transform component." +
	                   "\n\nThis is more efficient than setting the position and rotation separately.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetPositionAndRotation.html")]
	public sealed class TransformSetPositionAndRotation : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Rotation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _position, _rotation);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.SetPositionAndRotation(_position.Value, _rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Position {_position} Rotation {_rotation} ";
		}
	}
}
