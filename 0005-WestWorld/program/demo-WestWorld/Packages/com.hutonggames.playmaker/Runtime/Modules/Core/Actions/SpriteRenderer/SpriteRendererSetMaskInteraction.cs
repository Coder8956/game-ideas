
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Specifies how the sprite interacts with the masks.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-maskInteraction.html")]
	public sealed class SpriteRendererSetMaskInteraction : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Mask Interaction")]
		[SerializeField]
		private SpriteMaskInteractionVar _setMaskInteraction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setMaskInteraction);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.maskInteraction = _setMaskInteraction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Mask Interaction to {_setMaskInteraction}";
		}
	}
}
