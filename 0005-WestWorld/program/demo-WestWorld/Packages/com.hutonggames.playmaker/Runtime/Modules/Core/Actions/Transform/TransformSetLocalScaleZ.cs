
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the Z scale of the transform relative to the GameObjects parent.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformSetLocalScaleZ : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Z Scale")]
		[SerializeField]
		private FloatVar _setLocalScaleZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalScaleZ);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			var localScale = transform.localScale;
			localScale.z = _setLocalScaleZ.Value;
			transform.localScale = localScale;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Scale Z to {_setLocalScaleZ}";
		}
	}
}
