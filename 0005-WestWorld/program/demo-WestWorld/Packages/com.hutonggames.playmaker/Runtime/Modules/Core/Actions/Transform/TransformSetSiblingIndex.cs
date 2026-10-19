
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Sets the sibling index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetSiblingIndex.html")]
	public sealed class TransformSetSiblingIndex : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Index to set.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _index);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.SetSiblingIndex(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Sibling Index {_transform} {_index} ";
		}
	}
}
