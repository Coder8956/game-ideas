
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("If not null, the camera will only render the contents of the specified Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-scene.html")]
	public sealed class CameraGetScene : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Scene")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _getScene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getScene);
		}
		
		public override void Execute()
		{
			_getScene.Value = _camera.Value.scene;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} scene -> {_getScene}";
		}
	}
}
