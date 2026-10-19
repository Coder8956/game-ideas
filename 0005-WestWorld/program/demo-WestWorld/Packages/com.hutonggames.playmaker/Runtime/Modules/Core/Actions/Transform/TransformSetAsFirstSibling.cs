
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Move the transform to the start of the local transform list.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetAsFirstSibling.html")]
	public sealed class TransformSetAsFirstSibling : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.SetAsFirstSibling();
		}
		
		public override string GetSummary()
		{
			return "Set As First Sibling {_transform} ";
		}
	}
}
