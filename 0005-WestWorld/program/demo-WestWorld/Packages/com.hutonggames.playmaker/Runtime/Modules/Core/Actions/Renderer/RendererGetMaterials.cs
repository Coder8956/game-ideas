
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns all the instantiated materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-materials.html")]
	public sealed class RendererGetMaterials : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Materials")]
		[SerializeField]
		[WriteOnly]
		private MaterialListRef _getMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getMaterials);
		}
		
		public override void Execute()
		{
			_getMaterials.Values = _renderer.Value.materials;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} materials -> {_getMaterials}";
		}
	}
}
