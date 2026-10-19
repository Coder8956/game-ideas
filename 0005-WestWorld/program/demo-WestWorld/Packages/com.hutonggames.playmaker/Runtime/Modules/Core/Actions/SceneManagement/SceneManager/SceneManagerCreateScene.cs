
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[Obsolete("Use CreateScene instead")] 
	[DisplayName("Scene Manager Create Scene (OldAPI)")]
	[ActionDescription("Create an empty new Scene at runtime with the given name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.CreateScene.html")]
	public sealed class SceneManagerCreateScene : BaseAction
	{
		
		[Tooltip("The name of the new Scene. It cannot be empty or null, or same as the name of the existing Scenes.")]
		[SerializeField]
		private StringVar _sceneName;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneName, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.CreateScene(System.String);
			_result.Value = UnityEngine.SceneManagement.SceneManager.CreateScene(_sceneName.Value);
		}
		
		public override string GetSummary()
		{
			return "Create scene {_sceneName} -> {_result}";
		}
	}
}
