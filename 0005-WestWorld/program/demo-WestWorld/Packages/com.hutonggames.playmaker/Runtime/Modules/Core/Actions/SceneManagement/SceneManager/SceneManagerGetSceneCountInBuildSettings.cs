
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("Number of Scenes in Build Settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneCountInBuildSettings.html")]
	public sealed class SceneManagerGetSceneCountInBuildSettings : BaseAction
	{
		
		[Tooltip("Get SceneManager Scene Count In Build Settings")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSceneCountInBuildSettings;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSceneCountInBuildSettings);
		}
		
		public override void Execute()
		{
			_getSceneCountInBuildSettings.Value = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
		}
		
		public override string GetSummary()
		{
			return "Get scene count in build settings -> {_getSceneCountInBuildSettings}";
		}
	}
}
