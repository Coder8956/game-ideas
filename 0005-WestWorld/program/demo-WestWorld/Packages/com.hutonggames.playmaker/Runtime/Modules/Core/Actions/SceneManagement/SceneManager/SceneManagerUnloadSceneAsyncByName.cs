
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
	public sealed class SceneManagerUnloadSceneAsyncByName : BaseAction
	{
		
		[Tooltip("Name of the Scene in the Build Settings to unload.")]
		[SerializeField]
		private StringVar _sceneName;

		[Tooltip("Options.")]
		[SerializeField]
		private UnloadSceneOptions _options;
		
		public override bool CanExecute() => CheckParameters(_sceneName, _options);

		public override void Execute() => SceneManager.UnloadSceneAsync(_sceneName.Value, _options);

		public override string GetSummary() => "Unload scene {_sceneName} {_options}";
	}
}
