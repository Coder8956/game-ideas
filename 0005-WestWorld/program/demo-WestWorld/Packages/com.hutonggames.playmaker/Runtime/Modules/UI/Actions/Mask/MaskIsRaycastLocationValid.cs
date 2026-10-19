
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Mask)]
	[ActionDescription("See:ICanvasRaycastFilter.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Mask.html")]
	public sealed class MaskIsRaycastLocationValid : BaseAction
	{
		
		[Tooltip("The Mask.")]
		[SerializeField]
		private MaskVar _mask;
		
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
			return CheckParameters(_mask, _sp, _eventCamera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Mask.IsRaycastLocationValid(UnityEngine.Vector2, UnityEngine.Camera);
			_result.Value = _mask.Value.IsRaycastLocationValid(_sp.Value, _eventCamera.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_mask} raycast location {_sp} {_eventCamera} -> {_result}";
		}
	}
}
