
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The shared material of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterial.html")]
	public sealed class RendererGetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Shared Material")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _getSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getSharedMaterial);
		}
		
		public override void Execute()
		{
			_getSharedMaterial.Value = _renderer.Value.sharedMaterial;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} sharedMaterial -> {_getSharedMaterial}";
		}
	}
}
