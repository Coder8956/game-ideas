
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Returns true if the Scene is modified.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-isDirty.html")]
	public sealed class SceneGetIsDirty : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Is Dirty")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsDirty;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getIsDirty);
		}
		
		public override void Execute()
		{
			_getIsDirty.Value = _scene.Value.isDirty;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} is dirty -> {_getIsDirty}";
		}
	}
}
