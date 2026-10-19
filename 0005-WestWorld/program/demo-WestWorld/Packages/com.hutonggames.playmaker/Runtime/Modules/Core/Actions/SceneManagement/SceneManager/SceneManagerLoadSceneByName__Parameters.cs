
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[DisplayName("Scene Manager Load Scene By Name")]
	[ActionDescription("Loads the Scene by its name or index in Build Settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html")]
	public sealed class SceneManagerLoadSceneByName__Parameters : BaseAction
	{
		
		[Tooltip("Name or path of the Scene to load.")]
		[SerializeField]
		private StringVar _sceneName;
		
		[Tooltip("Various parameters used to load the Scene.")]
		[SerializeField, NoFoldout]
		private LoadSceneParameters _parameters;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[OptionalField, WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneName, _parameters);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.LoadScene(System.String, UnityEngine.SceneManagement.LoadSceneParameters);
			var scene = SceneManager.LoadScene(_sceneName.Value, _parameters);

			if (_result.IsAssigned)
			{
				_result.Value = scene;
			}
		}
		
		public override string GetSummary()
		{
			return "Load scene {_sceneName} -> {_result} ({_parameters})";
		}
	}
}
