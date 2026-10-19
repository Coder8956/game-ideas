
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Specifies how the sprite interacts with the masks.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-maskInteraction.html")]
	public sealed class SpriteRendererGetMaskInteraction : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Mask Interaction")]
		[SerializeField]
		[WriteOnly]
		private SpriteMaskInteractionRef _getMaskInteraction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getMaskInteraction);
		}
		
		public override void Execute()
		{
			_getMaskInteraction.Value = _spriteRenderer.Value.maskInteraction;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Mask Interaction -> {_getMaskInteraction}";
		}
	}
}
