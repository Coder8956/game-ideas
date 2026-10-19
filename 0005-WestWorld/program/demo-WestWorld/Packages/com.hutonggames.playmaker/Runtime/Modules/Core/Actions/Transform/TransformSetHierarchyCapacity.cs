
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The transform capacity of the transform\'s hierarchy data structure.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hierarchyCapacity.html")]
	public sealed class TransformSetHierarchyCapacity : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Hierarchy Capacity")]
		[SerializeField]
		private IntegerVar _setHierarchyCapacity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setHierarchyCapacity);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.hierarchyCapacity = _setHierarchyCapacity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Hierarchy Capacity to {_setHierarchyCapacity}";
		}
	}
}
