
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns all the instantiated materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.GetMaterials.html")]
	public sealed class RendererGetMaterials__NonAlloc : BaseAction
	{
		[OwnerDefaultValue]
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
			//UnityEngine.Renderer.GetMaterials(System.Collections.Generic.List`1[[UnityEngine.Material, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			_renderer.Value.GetMaterials(_materials.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Materials {_renderer} {_materials} ";
		}
	}
}
