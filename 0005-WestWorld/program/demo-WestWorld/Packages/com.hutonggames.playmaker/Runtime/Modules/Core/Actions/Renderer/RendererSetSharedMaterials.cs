
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("All the shared materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterials.html")]
	public sealed class RendererSetSharedMaterials : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Shared Materials")]
		[SerializeField]
		private MaterialListVar _setSharedMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setSharedMaterials);
		}
		
		public override void Execute()
		{
			_renderer.Value.sharedMaterials = _setSharedMaterials.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Shared Materials to {_setSharedMaterials}";
		}
	}
}
