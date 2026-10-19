
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
	public sealed class SpriteRendererSetSize : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Size")]
		[SerializeField]
		private Vector2Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setSize);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.size = _setSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Size to {_setSize}";
		}
	}
}
