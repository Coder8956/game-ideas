
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Returns the name of the Scene that is currently active in the game or app.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-name.html")]
	public sealed class SceneGetName : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Name")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getName);
		}
		
		public override void Execute()
		{
			_getName.Value = _scene.Value.name;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} name -> {_getName}";
		}
	}
}
