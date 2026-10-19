
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the Y scale of the transform relative to the GameObjects parent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformSetLocalScaleY : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Y Scale")]
		[SerializeField]
		private FloatVar _setLocalScaleY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalScaleY);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			var localScale = transform.localScale;
			localScale.y = _setLocalScaleY.Value;
			transform.localScale = localScale;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Scale Y to {_setLocalScaleY}";
		}
	}
}
