
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("When a GraphicRaycaster is raycasting into the scene it does two things. First it" +
		" filters the elements using their RectTransform rect. Then it uses this Raycast " +
		"function to determine the elements hit by the raycast.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicRaycast : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Screen point.")]
		[SerializeField]
		private Vector2Var _sp;
		
		[Tooltip("Camera.")]
		[SerializeField]
		private CameraVar _eventCamera;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _sp, _eventCamera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.Raycast(UnityEngine.Vector2, UnityEngine.Camera);
			_result.Value = _graphic.Value.Raycast(_sp.Value, _eventCamera.Value);
		}
		
		public override string GetSummary()
		{
			return "Raycast {_graphic} {_sp} {_eventCamera} -> {_result}";
		}
	}
}
