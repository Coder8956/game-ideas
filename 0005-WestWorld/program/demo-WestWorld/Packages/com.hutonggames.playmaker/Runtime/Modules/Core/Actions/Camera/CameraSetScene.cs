
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
	public sealed class CameraSetScene : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Scene")]
		[SerializeField]
		private SceneVar _setScene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setScene);
		}
		
		public override void Execute()
		{
			_camera.Value.scene = _setScene.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} scene to {_setScene}";
		}
	}
}
