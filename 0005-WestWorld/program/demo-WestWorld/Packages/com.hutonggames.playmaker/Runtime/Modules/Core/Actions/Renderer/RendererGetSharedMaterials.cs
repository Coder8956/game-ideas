
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("All the shared materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterials.html")]
	public sealed class RendererGetSharedMaterials : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Shared Materials")]
		[SerializeField]
		[WriteOnly]
		private MaterialListRef _getSharedMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getSharedMaterials);
		}
		
		public override void Execute()
		{
			_getSharedMaterials.Values = _renderer.Value.sharedMaterials;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} sharedMaterials -> {_getSharedMaterials}";
		}
	}
}
