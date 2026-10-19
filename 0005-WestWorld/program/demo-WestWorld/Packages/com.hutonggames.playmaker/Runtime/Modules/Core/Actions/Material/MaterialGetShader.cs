
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The shader used by the material.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-shader.html")]
	public sealed class MaterialGetShader : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Get Material Shader")]
		[SerializeField]
		[WriteOnly]
		private ShaderRef _getShader;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _getShader);
		}
		
		public override void Execute()
		{
			_getShader.Value = _material.Value.shader;
		}
		
		public override string GetSummary()
		{
			return "Get {_material} shader -> {_getShader}";
		}
	}
}
