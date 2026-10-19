
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Property to set or get the size to render when the SpriteRenderer.drawMode is set" +
		" to SpriteDrawMode.Sliced or SpriteDrawMode.Tiled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-size.html")]
	public sealed class SpriteRendererGetSize : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Size")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _spriteRenderer.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Size -> {_getSize}";
		}
	}
}
