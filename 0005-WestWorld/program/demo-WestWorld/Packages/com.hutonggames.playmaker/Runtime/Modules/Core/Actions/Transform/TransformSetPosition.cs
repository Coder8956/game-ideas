
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the world space position of the Transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
	public sealed class TransformSetPosition : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Position")]
		[SerializeField]
		private Vector3Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setPosition);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.position = _setPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Position to {_setPosition}";
		}
	}
}
