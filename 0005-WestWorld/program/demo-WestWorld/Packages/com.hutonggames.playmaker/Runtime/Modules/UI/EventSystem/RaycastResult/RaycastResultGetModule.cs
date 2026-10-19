using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("BaseRaycaster that raised this event.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetModule : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Module")]
		[SerializeField]
		[WriteOnly]
		private ComponentRef _getModule;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getModule);
		}
		
		public override void Execute()
		{
			_getModule.Value = _raycastResult.Value.module;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} module -> {_getModule}";
		}
	}
}
