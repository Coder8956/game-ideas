
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTexture.html")]
	public sealed class MaterialGetMainTexture : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Get Material Main Texture")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _getMainTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _getMainTexture);
		}
		
		public override void Execute()
		{
			_getMainTexture.Value = _material.Value.mainTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_material} mainTexture -> {_getMainTexture}";
		}
	}
}
