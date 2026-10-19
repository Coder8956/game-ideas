
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The shader used by the material.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-shader.html")]
	public sealed class MaterialSetShader : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Set Material Shader")]
		[SerializeField]
		private ShaderVar _setShader;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _setShader);
		}
		
		public override void Execute()
		{
			_material.Value.shader = _setShader.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_material} Shader to {_setShader}";
		}
	}
}
