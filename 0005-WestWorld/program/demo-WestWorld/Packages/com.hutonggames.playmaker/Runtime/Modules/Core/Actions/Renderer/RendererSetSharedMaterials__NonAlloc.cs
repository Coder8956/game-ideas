
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Assigns the shared materials of this object using the list of materials provided." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.SetSharedMaterials.html")]
	public sealed class RendererSetSharedMaterials__NonAlloc : BaseAction
	{
		
		[Tooltip("The Renderer.")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Materials.")]
		[SerializeField]
		private MaterialListVar _materials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _materials);
		}
		
		public override void Execute()
		{
			_renderer.Value.SetSharedMaterials(_materials.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Shared Materials {_renderer} {_materials} ";
		}
	}
}
