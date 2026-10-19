
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The rotation of the transform relative to the transform rotation of the parent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localRotation.html")]
	public sealed class TransformSetLocalRotation : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Rotation")]
		[SerializeField]
		private QuaternionVar _setLocalRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalRotation);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.localRotation = _setLocalRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} local rotation to {_setLocalRotation}";
		}
	}
}
