using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Display index of the hit object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetDisplayIndex : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Display Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getDisplayIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getDisplayIndex);
		}
		
		public override void Execute()
		{
			_getDisplayIndex.Value = _raycastResult.Value.displayIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} display index -> {_getDisplayIndex}";
		}
	}
}
