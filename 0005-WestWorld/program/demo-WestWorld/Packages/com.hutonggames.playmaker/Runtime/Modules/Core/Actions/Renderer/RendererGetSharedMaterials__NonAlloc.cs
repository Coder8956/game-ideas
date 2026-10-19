
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns all the shared materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.GetSharedMaterials.html")]
	public sealed class RendererGetSharedMaterials__NonAlloc : BaseAction
	{
		
		[Tooltip("The Renderer.")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("A list of materials to populate.")]
		[SerializeField, WriteOnly]
		private MaterialListRef _materials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _materials);
		}
		
		public override void Execute()
		{
			_renderer.Value.GetSharedMaterials(_materials.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Shared Materials {_renderer} {_materials} ";
		}
	}
}
