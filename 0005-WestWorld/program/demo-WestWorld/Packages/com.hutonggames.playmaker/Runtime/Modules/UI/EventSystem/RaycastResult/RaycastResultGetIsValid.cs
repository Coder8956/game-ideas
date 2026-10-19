using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastResult)]
	[ActionDescription("Whether this RaycastResult is valid.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.RaycastResult.html")]
	public sealed class RaycastResultGetIsValid : BaseAction
	{
		
		[Tooltip("The RaycastResult")]
		[SerializeField]
		private RaycastResultRef _raycastResult;
		
		[Tooltip("Get RaycastResult Is Valid")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsValid;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastResult, _getIsValid);
		}
		
		public override void Execute()
		{
			_getIsValid.Value = _raycastResult.Value.isValid;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastResult} is valid -> {_getIsValid}";
		}
	}
}
