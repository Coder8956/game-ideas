
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SceneManager)]
	[Obsolete("Use LoadSceneByIndex instead")] 
	[DisplayName("Scene Manager Load Scene By Index (OldAPI)")]
	[ActionDescription("Loads the Scene by its index in Build Settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html")]
	public sealed class SceneManagerLoadSceneByIndex : BaseAction
	{
		
		[Tooltip("Index of the Scene in the Build Settings to load.")]
		[SerializeField]
		private IntegerVar _sceneBuildIndex;
		
		[Tooltip("Allows you to specify whether or not to load the Scene additively.")]
		[SerializeField]
		private LoadSceneMode _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_sceneBuildIndex, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.SceneManagement.SceneManager.LoadScene(System.Int32, UnityEngine.SceneManagement.LoadSceneMode);
			SceneManager.LoadScene(_sceneBuildIndex.Value, _mode);
		}
		
		public override string GetSummary()
		{
			return "Load scene {_sceneBuildIndex} {_mode}";
		}
	}
}
