
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns true if the Renderer has a material property block attached via SetPropertyBlock.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.HasPropertyBlock.html")]
	public sealed class RendererHasPropertyBlock : BaseAction
	{
		
		[Tooltip("The Renderer.")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Renderer.HasPropertyBlock();
			_result.Value = _renderer.Value.HasPropertyBlock();
		}
		
		public override string GetSummary()
		{
			return "Has Property Block {_renderer} -> {_result}";
		}
	}
}
