
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("IsLoaded is set to true after loading has completed and objects have been enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-isLoaded.html")]
	public sealed class SceneGetIsLoaded : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Is Loaded")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsLoaded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getIsLoaded);
		}
		
		public override void Execute()
		{
			_getIsLoaded.Value = _scene.Value.isLoaded;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} is loaded -> {_getIsLoaded}";
		}
	}
}
