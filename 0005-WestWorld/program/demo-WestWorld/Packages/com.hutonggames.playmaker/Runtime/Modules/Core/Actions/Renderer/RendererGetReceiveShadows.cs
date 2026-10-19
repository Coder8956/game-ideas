
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Does this object receive shadows?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-receiveShadows.html")]
	public sealed class RendererGetReceiveShadows : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Receive Shadows")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getReceiveShadows;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getReceiveShadows);
		}
		
		public override void Execute()
		{
			_getReceiveShadows.Value = _renderer.Value.receiveShadows;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} receiveShadows -> {_getReceiveShadows}";
		}
	}
}
