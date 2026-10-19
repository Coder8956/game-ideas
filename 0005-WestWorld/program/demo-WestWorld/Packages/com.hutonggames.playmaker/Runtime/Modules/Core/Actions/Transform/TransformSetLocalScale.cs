
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the scale of the transform relative to the GameObjects parent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformSetLocalScale : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Scale")]
		[SerializeField]
		private Vector3Var _setLocalScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalScale);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.localScale = _setLocalScale.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Scale to {_setLocalScale}";
		}
	}
}
