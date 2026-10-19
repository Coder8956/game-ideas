
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Rendering color for the Sprite graphic.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-color.html")]
	public sealed class SpriteRendererSetColor : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setColor);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.color = _setColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Color to {_setColor}";
		}
	}
}
