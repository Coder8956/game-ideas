
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Returns the relative path of the Scene. For example: \"Assets/MyScenes/MyScene.unity\".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-path.html")]
	public sealed class SceneGetPath : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Path")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getPath);
		}
		
		public override void Execute()
		{
			_getPath.Value = _scene.Value.path;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} path -> {_getPath}";
		}
	}
}
