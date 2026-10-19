
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Send event when a Scene has unloaded.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneUnloaded.html")]
	public sealed class SceneManagerOnSceneUnloaded : BaseOnEventAction
	{
		
		[Tooltip("Event sent when a Scene has unloaded.")]
		[SerializeField]
		private EventRef _sceneUnloaded;
		
		[OptionalField]
		[Tooltip("The scene that was unloaded.")]
		[SerializeField, WriteOnly]
		private SceneRef _scene;
		
		public override void OnStart()
		{
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}
		
		public override void OnStop()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
		}
		
		private void OnSceneUnloaded(Scene scene)
		{
			_scene.Value = scene;
			SendEvent(_sceneUnloaded);
		}
		
		public override string GetSummary() => "On scene unloaded {_sceneUnloaded}";
	}
}
