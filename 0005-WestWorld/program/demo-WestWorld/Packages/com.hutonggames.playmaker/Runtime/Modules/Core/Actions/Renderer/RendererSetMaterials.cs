
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Sets the instantiated materials of this object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-materials.html")]
	public sealed class RendererSetMaterials : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Materials")]
		[SerializeField]
		private MaterialListVar _setMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setMaterials);
		}
		
		public override void Execute()
		{
			_renderer.Value.materials = _setMaterials.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Materials to {_setMaterials}";
		}
	}
}
