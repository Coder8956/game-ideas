
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Rendering color for the Sprite graphic.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-color.html")]
	public sealed class SpriteRendererGetColor : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getColor);
		}
		
		public override void Execute()
		{
			_getColor.Value = _spriteRenderer.Value.color;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Color -> {_getColor}";
		}
	}
}
