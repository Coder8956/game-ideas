
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Searches all Scenes loaded for a Scene that has the given asset path.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneByPath.html")]
	public sealed class SceneManagerGetSceneByPath : BaseAction
	{
		
		[Tooltip("Path of the Scene. Should be relative to the project folder. Like: \"AssetsMyScenesMyScene.unity\".")]
		[SerializeField]
		private StringVar _scenePath;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scenePath, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.GetSceneByPath(System.String);
			_result.Value = UnityEngine.SceneManagement.SceneManager.GetSceneByPath(_scenePath.Value);
		}
		
		public override string GetSummary()
		{
			return "Get scene by path {_scenePath} -> {_result}";
		}
	}
}
