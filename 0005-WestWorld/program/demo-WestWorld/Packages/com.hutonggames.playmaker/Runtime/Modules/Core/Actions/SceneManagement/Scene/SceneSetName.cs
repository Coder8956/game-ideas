
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
	public sealed class SceneSetName : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Set Scene Name")]
		[SerializeField]
		private StringVar _setName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _setName);
		}
		
		public override void Execute()
		{
			var value = _scene.Value;
			value.name = _setName.Value;
			_scene.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scene} name to {_setName}";
		}
	}
}
