
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Set the Scene to be active.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.SetActiveScene.html")]
	public sealed class SceneManagerSetActiveScene : BaseAction
	{
		
		[Tooltip("The Scene to be set.")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("False if the scene is not loaded yet, otherwise true.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _isLoaded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _isLoaded);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.Scene);
			_isLoaded.Value = SceneManager.SetActiveScene(_scene.Value);
		}
		
		public override string GetSummary()
		{
			return "Set active scene to {_scene}";
		}
	}
}
