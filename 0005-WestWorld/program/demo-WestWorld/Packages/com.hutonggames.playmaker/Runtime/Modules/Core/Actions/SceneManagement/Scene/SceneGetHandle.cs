/* Undocumented property
 
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Scene)]
	[ActionDescription("Gets Handle from Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-handle.html")]
	public sealed class SceneGetHandle : BaseAction
	{
		
		[Tooltip("The Scene")]
		[SerializeField]
		private HutongGames.PlayMaker.SceneRef _scene;
		
		[Tooltip("Get Scene Handle")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getHandle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scene, _getHandle);
		}
		
		public override void Execute()
		{
			this._getHandle.Value = this._scene.Value.handle;
		}
		
		public override string GetSummary()
		{
			return "Get {_scene} handle -> {_getHandle}";
		}
	}
}
*/
