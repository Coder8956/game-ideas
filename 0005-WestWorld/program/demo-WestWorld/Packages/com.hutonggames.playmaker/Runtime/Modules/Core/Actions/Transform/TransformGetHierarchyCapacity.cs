
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The transform capacity of the transform\'s hierarchy data structure.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hierarchyCapacity.html")]
	public sealed class TransformGetHierarchyCapacity : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Get Transform Hierarchy Capacity")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getHierarchyCapacity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _getHierarchyCapacity);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_getHierarchyCapacity.Value = transform.hierarchyCapacity;
		}
		
		public override string GetSummary()
		{
			return "Get {_transform} hierarchyCapacity -> {_getHierarchyCapacity}";
		}
	}
}
