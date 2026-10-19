
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasGroup)]
	[ActionDescription("Returns true if the Group allows raycasts.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasGroup.IsRaycastLocationValid.html")]
	public sealed class CanvasGroupIsRaycastLocationValid : BaseAction
	{
		
		[Tooltip("The CanvasGroup.")]
		[SerializeField]
		private CanvasGroupVar _canvasGroup;
		
		[Tooltip("Sp.")]
		[SerializeField]
		private Vector2Var _sp;
		
		[Tooltip("Event Camera.")]
		[SerializeField]
		private CameraVar _eventCamera;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasGroup, _sp, _eventCamera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasGroup.IsRaycastLocationValid(UnityEngine.Vector2, UnityEngine.Camera);
			_result.Value = _canvasGroup.Value.IsRaycastLocationValid(_sp.Value, _eventCamera.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_canvasGroup} raycast location {_sp} {_eventCamera} -> {_result}";
		}
	}
}
