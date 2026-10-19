
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The current draw mode of the Sprite Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-drawMode.html")]
	public sealed class SpriteRendererSetDrawMode : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Draw Mode")]
		[SerializeField]
		private SpriteDrawModeVar _setDrawMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setDrawMode);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.drawMode = _setDrawMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Draw Mode to {_setDrawMode}";
		}
	}
}
