
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Send event when the active Scene has changed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-activeSceneChanged.html")]
	public sealed class SceneManagerOnActiveSceneChanged : BaseOnEventAction
	{
		
		[Tooltip("Event sent when the active Scene has changed.")]
		[SerializeField]
		private EventRef _activeSceneChanged;

		[OptionalField]
		[Tooltip("The scene being replaced.")]
		[SerializeField, WriteOnly]
		private SceneRef _currentScene;

		[OptionalField]
		[Tooltip("The scene becoming active.")]
		[SerializeField, WriteOnly]
		private SceneRef _nextScene;
		
		public override void OnStart()
		{
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
		}
		
		public override void OnStop()
		{
			SceneManager.activeSceneChanged -= OnActiveSceneChanged;
		}
		
		private void OnActiveSceneChanged(Scene currentScene, Scene nextScene)
		{
			_currentScene.Value = currentScene;
			_nextScene.Value = nextScene;
			SendEvent(_activeSceneChanged);
		}

		public override string GetSummary() => "On active scene changed {_activeSceneChanged}";
	}
}
