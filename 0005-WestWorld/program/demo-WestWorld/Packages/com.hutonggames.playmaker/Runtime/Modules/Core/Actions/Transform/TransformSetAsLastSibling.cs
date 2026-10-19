
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Move the transform to the end of the local transform list.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetAsLastSibling.html")]
	public sealed class TransformSetAsLastSibling : BaseAction
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
			transform.SetAsLastSibling();
		}
		
		public override string GetSummary()
		{
			return "Set As Last Sibling {_transform} ";
		}
	}
}
