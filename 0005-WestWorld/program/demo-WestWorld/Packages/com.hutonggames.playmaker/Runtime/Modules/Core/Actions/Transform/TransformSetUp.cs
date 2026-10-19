
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The green axis of the transform in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-up.html")]
	public sealed class TransformSetUp : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Up")]
		[SerializeField]
		private Vector3Var _setUp;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setUp);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.up = _setUp.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Up to {_setUp}";
		}
	}
}
