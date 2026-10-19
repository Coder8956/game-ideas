
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{


	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Destroys all GameObjects associated with the given Scene and removes the Scene from the SceneManager.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.UnloadSceneAsync.html")]
	public sealed class SceneManagerUnloadSceneAsync : BaseAction
	{
		
		[Tooltip("Scene to unload. Stored from a previous Get Scene action.")]
		[SerializeField]
		private SceneRef _scene;

		[Tooltip("Options.")]
		[SerializeField]
		private UnloadSceneOptions _options;
		
		public override bool CanExecute() => CheckParameters(_scene, _options);

		public override void Execute() => SceneManager.UnloadSceneAsync(_scene.Value, _options);

		public override string GetSummary() => "Unload scene {_scene} {_options}";
	}
}
