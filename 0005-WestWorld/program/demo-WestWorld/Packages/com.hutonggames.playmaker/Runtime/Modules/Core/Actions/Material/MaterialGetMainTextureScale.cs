
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The scale of the main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTextureScale.html")]
	public sealed class MaterialGetMainTextureScale : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Get Material Main Texture Scale")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMainTextureScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _getMainTextureScale);
		}
		
		public override void Execute()
		{
			_getMainTextureScale.Value = _material.Value.mainTextureScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_material} mainTextureScale -> {_getMainTextureScale}";
		}
	}
}
