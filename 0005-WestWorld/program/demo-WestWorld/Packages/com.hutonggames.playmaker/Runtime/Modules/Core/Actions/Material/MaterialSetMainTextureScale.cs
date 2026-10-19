
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The scale of the main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTextureScale.html")]
	public sealed class MaterialSetMainTextureScale : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Set Material Main Texture Scale")]
		[SerializeField]
		private Vector2Var _setMainTextureScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _setMainTextureScale);
		}
		
		public override void Execute()
		{
			_material.Value.mainTextureScale = _setMainTextureScale.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_material} Main Texture Scale to {_setMainTextureScale}";
		}
	}
}
