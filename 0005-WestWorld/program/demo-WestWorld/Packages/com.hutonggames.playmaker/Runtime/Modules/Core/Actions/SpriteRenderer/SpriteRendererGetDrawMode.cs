
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The current draw mode of the Sprite Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-drawMode.html")]
	public sealed class SpriteRendererGetDrawMode : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Draw Mode")]
		[SerializeField]
		[WriteOnly]
		private SpriteDrawModeRef _getDrawMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getDrawMode);
		}
		
		public override void Execute()
		{
			_getDrawMode.Value = _spriteRenderer.Value.drawMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Draw Mode -> {_getDrawMode}";
		}
	}
}
