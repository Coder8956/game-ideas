/* TODO ECS Support
 
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.SceneManagement
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Gets Is Sub Scene from Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-isSubScene.html")]
	public sealed class SceneGetIsSubScene : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private SceneRef _scene;
		
		[Tooltip("Get Scene Is Sub Scene")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsSubScene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getIsSubScene);
		}
		
		public override void Execute()
		{
			_getIsSubScene.Value = _scene.Value.isSubScene;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} is sub scene -> {_getIsSubScene}";
		}
	}
}
*/
