using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Sorting layer of the hit object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetSortingLayer : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Sorting Layer")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingLayer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getSortingLayer);
		}
		
		public override void Execute()
		{
			_getSortingLayer.Value = _raycastResult.Value.sortingLayer;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} sorting layer -> {_getSortingLayer}";
		}
	}
}
