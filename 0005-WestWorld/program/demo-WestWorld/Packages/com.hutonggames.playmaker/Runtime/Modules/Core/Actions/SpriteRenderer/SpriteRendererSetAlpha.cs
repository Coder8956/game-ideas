
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Set the rendering alpha for the Sprite graphic, keeping the current color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-color.html")]
	public sealed class SpriteRendererSetAlpha : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Color")]
		[SerializeField, DefaultValue(1f), VarSlider(0,1)]
		private FloatVar _setAlpha;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer, _setAlpha);

		public override void Execute()
		{
			var color = _spriteRenderer.Value.color;
			color.a = _setAlpha.Value;
			_spriteRenderer.Value.color = color;
		}

		public override string GetSummary()
		{
			return "Set {_spriteRenderer} alpha to {_setAlpha}";
		}
	}
}
