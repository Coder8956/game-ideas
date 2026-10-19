
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("The number of root transforms of this Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-rootCount.html")]
	public sealed class SceneGetRootCount : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Root Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getRootCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getRootCount);
		}
		
		public override void Execute()
		{
			_getRootCount.Value = _scene.Value.rootCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} root count -> {_getRootCount}";
		}
	}
}
