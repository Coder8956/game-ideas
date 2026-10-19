
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[DisplayName("Scene Manager Create Scene")]
	[ActionDescription("Create an empty new Scene at runtime with the given name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.CreateScene.html")]
	public sealed class SceneManagerCreateScene__Parameters : BaseAction
	{
		
		[Tooltip("The name of the new Scene. It cannot be empty or null, or same as the name of the existing Scenes.")]
		[SerializeField]
		private StringVar _sceneName;
		
		[Tooltip("Various parameters used to create the Scene.")]
		[SerializeField, NoFoldout]
		private CreateSceneParameters _parameters;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneName, _parameters, _result);
		}
		
		public override void Execute()
		{
			_result.Value = SceneManager.CreateScene(_sceneName.Value, _parameters);
		}
		
		public override string GetSummary()
		{
			return "Create scene {_sceneName} -> {_result} ({_parameters})";
		}
	}
}
