
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Returns a normalized vector representing the blue axis of the transform in world " +
		"space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-forward.html")]
	public sealed class TransformSetForward : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Forward")]
		[SerializeField]
		private Vector3Var _setForward;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setForward);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.forward = _setForward.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Forward to {_setForward}";
		}
	}
}
