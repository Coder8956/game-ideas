
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Get a Scene struct from a build index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneByBuildIndex.html")]
	public sealed class SceneManagerGetSceneByBuildIndex : BaseAction
	{
		
		[Tooltip("Build index as shown in the Build Settings window.")]
		[SerializeField]
		private IntegerVar _buildIndex;
		
		[Tooltip("Store the result in Scene variable.")]
		[SerializeField]
		[WriteOnly]
		private SceneRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_buildIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(System.Int32);
			_result.Value = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(_buildIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Get scene by build index {_buildIndex} -> {_result}";
		}
	}
}
