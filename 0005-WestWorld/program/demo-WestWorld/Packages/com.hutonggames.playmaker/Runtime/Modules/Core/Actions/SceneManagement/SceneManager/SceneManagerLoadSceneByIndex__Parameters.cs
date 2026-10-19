
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[DisplayName("Scene Manager Load Scene By Index")]
	[ActionDescription("Loads the Scene by its index in Build Settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html")]
	public sealed class SceneManagerLoadSceneByIndex__Parameters : BaseAction
	{
		
		[Tooltip("Index of the Scene in the Build Settings to load.")]
		[SerializeField]
		private IntegerVar _sceneBuildIndex;
		
		[Tooltip("Various parameters used to load the Scene.")]
		[SerializeField, NoFoldout]
		private LoadSceneParameters _parameters;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[OptionalField, WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneBuildIndex, _parameters);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.LoadScene(System.Int32, UnityEngine.SceneManagement.LoadSceneParameters);
			var scene = SceneManager.LoadScene(_sceneBuildIndex.Value, _parameters);

			if (_result.IsAssigned)
			{
				_result.Value = scene;
			}
		}
		
		public override string GetSummary()
		{
			return "Load scene {_sceneBuildIndex} -> {_result} ({_parameters})";
		}
	}
}
