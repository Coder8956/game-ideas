
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Gets the sibling index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetSiblingIndex.html")]
	public sealed class TransformGetSiblingIndex : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _result);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_result.Value = transform.GetSiblingIndex();
		}
		
		public override string GetSummary()
		{
			return "Get Sibling Index {_transform} -> {_result}";
		}
	}
}
