
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The number of transforms in the transform\'s hierarchy data structure.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hierarchyCount.html")]
	public sealed class TransformGetHierarchyCount : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Get Transform Hierarchy Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getHierarchyCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _getHierarchyCount);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			_getHierarchyCount.Value = transform.hierarchyCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_transform} hierarchyCount -> {_getHierarchyCount}";
		}
	}
}
