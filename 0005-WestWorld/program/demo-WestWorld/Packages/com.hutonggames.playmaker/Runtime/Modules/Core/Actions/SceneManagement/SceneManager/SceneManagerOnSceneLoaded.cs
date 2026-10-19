
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Send event when a Scene has loaded.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html")]
	public sealed class SceneManagerOnSceneLoaded : BaseOnEventAction
	{
		
		[Tooltip("Event sent when a Scene has loaded.")]
		[SerializeField]
		private EventRef _sceneLoaded;
		
		[OptionalField]
		[Tooltip("The scene that was loaded.")]
		[SerializeField, WriteOnly]
		private SceneRef _scene;

		[OptionalField]
		[Tooltip("The mode used to load the scene.")]
		[SerializeField, WriteOnly]
		private LoadSceneModeRef _loadSceneMode;
		
		public override void OnStart()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
		
		public override void OnStop()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
		
		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			_scene.Value = scene;
			_loadSceneMode.Value = loadSceneMode;
			SendEvent(_sceneLoaded);
		}
		
		public override string GetSummary() => "On scene loaded {_sceneLoaded}";
	}
}
