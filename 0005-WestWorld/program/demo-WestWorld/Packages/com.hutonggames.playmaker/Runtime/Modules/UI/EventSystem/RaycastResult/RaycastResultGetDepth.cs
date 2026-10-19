using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Depth of the hit object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetDepth : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Depth")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getDepth);
		}
		
		public override void Execute()
		{
			_getDepth.Value = _raycastResult.Value.depth;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} depth -> {_getDepth}";
		}
	}
}
