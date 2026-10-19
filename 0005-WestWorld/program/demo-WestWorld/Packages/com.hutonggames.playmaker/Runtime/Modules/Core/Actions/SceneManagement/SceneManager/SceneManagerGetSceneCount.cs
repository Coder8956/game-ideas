
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[ActionDescription("The current number of Scenes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneCount.html")]
	public sealed class SceneManagerGetSceneCount : BaseAction
	{
		
		[Tooltip("Get SceneManager Scene Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSceneCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSceneCount);
		}
		
		public override void Execute()
		{
			_getSceneCount.Value = UnityEngine.SceneManagement.SceneManager.sceneCount;
		}
		
		public override string GetSummary()
		{
			return "Get scene count -> {_getSceneCount}";
		}
	}
}
