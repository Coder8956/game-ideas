
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Return the index of the Scene in the Build Settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html")]
	public sealed class SceneGetBuildIndex : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Build Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getBuildIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getBuildIndex);
		}
		
		public override void Execute()
		{
			_getBuildIndex.Value = _scene.Value.buildIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} build index -> {_getBuildIndex}";
		}
	}
}
