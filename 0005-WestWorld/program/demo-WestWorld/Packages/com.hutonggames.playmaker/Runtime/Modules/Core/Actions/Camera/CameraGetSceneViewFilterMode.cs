/* Not documented. Editor only.
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Gets Scene View Filter Mode from Camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-sceneViewFilterMode.html")]
	public sealed class CameraGetSceneViewFilterMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Scene View Filter Mode")]
		[SerializeField]
		[WriteOnly]
		private Camera_SceneViewFilterModeRef _getSceneViewFilterMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getSceneViewFilterMode);
		}
		
		public override void Execute()
		{
			_getSceneViewFilterMode.Value = _camera.Value.sceneViewFilterMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} scene view filter mode -> {_getSceneViewFilterMode}";
		}
	}
}
*/
