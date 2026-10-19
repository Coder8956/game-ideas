
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The red axis of the transform in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-right.html")]
	public sealed class TransformSetRight : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Right")]
		[SerializeField]
		private Vector3Var _setRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setRight);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.right = _setRight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Right to {_setRight}";
		}
	}
}
