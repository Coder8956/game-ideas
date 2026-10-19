
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns the first instantiated Material assigned to the renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-material.html")]
	public sealed class RendererSetMaterial : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Material")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _setMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer);
		}
		
		public override void Execute()
		{
			_renderer.Value.material = _setMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Material to {_setMaterial}";
		}
	}
}
