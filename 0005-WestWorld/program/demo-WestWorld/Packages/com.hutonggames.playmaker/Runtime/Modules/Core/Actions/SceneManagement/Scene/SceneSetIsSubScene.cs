/* TODO ECS Support
 
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Sets Is Sub Scene on Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-isSubScene.html")]
	public sealed class SceneSetIsSubScene : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private HutongGames.PlayMaker.SceneRef _scene;
		
		[Tooltip("Set Scene Is Sub Scene")]
		[SerializeField]
		[DefaultValue(true)]
		private HutongGames.PlayMaker.BoolVar _setIsSubScene;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _setIsSubScene);
		}
		
		public override void Execute()
		{
			var value = this._scene.Value;
			value.isSubScene = this._setIsSubScene.Value;
			this._scene.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scene} is sub scene to {_setIsSubScene}";
		}
	}
}
*/
