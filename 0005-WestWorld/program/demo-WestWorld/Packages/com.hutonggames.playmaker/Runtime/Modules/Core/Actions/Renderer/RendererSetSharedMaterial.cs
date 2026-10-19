
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The shared material of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterial.html")]
	public sealed class RendererSetSharedMaterial : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Shared Material")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _setSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer);
		}
		
		public override void Execute()
		{
			_renderer.Value.sharedMaterial = _setSharedMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Shared Material to {_setSharedMaterial}";
		}
	}
}
