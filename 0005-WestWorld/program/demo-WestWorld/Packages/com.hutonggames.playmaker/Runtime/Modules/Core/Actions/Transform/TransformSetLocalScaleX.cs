
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the X scale of the transform relative to the GameObjects parent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformSetLocalScaleX : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local X Scale")]
		[SerializeField]
		private FloatVar _setLocalScaleX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalScaleX);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			var localScale = transform.localScale;
			localScale.x = _setLocalScaleX.Value;
			transform.localScale = localScale;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Scale X to {_setLocalScaleX}";
		}
	}
}
