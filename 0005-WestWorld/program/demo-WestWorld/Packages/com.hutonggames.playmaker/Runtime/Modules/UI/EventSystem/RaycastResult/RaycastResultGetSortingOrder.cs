using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Sorting order of the hit object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetSortingOrder : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Sorting Order")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getSortingOrder);
		}
		
		public override void Execute()
		{
			_getSortingOrder.Value = _raycastResult.Value.sortingOrder;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} sorting order -> {_getSortingOrder}";
		}
	}
}
