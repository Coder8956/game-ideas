using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Hit index in the result set.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetIndex : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Index")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getIndex);
		}
		
		public override void Execute()
		{
			_getIndex.Value = _raycastResult.Value.index;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} index -> {_getIndex}";
		}
	}
}
