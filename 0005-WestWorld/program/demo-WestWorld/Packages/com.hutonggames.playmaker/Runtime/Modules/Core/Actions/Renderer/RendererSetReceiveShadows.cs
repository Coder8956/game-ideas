
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Does this object receive shadows?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-receiveShadows.html")]
	public sealed class RendererSetReceiveShadows : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Receive Shadows")]
		[SerializeField]
		private BoolVar _setReceiveShadows;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setReceiveShadows);
		}
		
		public override void Execute()
		{
			_renderer.Value.receiveShadows = _setReceiveShadows.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Receive Shadows to {_setReceiveShadows}";
		}
	}
}
