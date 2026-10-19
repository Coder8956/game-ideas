
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[Obsolete("Use LoadSceneByName instead")] 
	[DisplayName("Scene Manager Load Scene By Name (OldAPI)")]
	[ActionDescription("Loads the Scene by its name.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html")]
	public sealed class SceneManagerLoadSceneByName : BaseAction
	{
		
		[Tooltip("Name or path of the Scene to load.")]
		[SerializeField]
		private StringVar _sceneName;
		
		[Tooltip("Allows you to specify whether or not to load the Scene additively.")]
		[SerializeField]
		private LoadSceneModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneName, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.LoadScene(System.String, UnityEngine.SceneManagement.LoadSceneMode);
			SceneManager.LoadScene(_sceneName.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Load scene {_sceneName} {_mode}";
		}
	}
}
