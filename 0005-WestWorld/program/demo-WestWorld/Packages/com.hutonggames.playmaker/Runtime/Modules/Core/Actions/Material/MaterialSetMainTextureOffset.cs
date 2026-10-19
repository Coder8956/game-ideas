
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The offset of the main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTextureOffset.html")]
	public sealed class MaterialSetMainTextureOffset : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Set Material Main Texture Offset")]
		[SerializeField]
		private Vector2Var _setMainTextureOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _setMainTextureOffset);
		}
		
		public override void Execute()
		{
			_material.Value.mainTextureOffset = _setMainTextureOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_material} Main Texture Offset to {_setMainTextureOffset}";
		}
	}
}
