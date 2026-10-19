
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Position of the transform relative to the parent transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localPosition.html")]
	public sealed class TransformSetLocalPosition2D : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Position")]
		[SerializeField]
		private Vector2Var _setLocalPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalPosition);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.localPosition = _setLocalPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Position to {_setLocalPosition}";
		}
	}
}
