
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("The number of loaded Scenes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-loadedSceneCount.html")]
	public sealed class SceneManagerGetLoadedSceneCount : BaseAction
	{
		
		[Tooltip("Get SceneManager Loaded Scene Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLoadedSceneCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getLoadedSceneCount);
		}
		
		public override void Execute()
		{
			_getLoadedSceneCount.Value = UnityEngine.SceneManagement.SceneManager.loadedSceneCount;
		}
		
		public override string GetSummary()
		{
			return "Get loaded scene count -> {_getLoadedSceneCount}";
		}
	}
}
