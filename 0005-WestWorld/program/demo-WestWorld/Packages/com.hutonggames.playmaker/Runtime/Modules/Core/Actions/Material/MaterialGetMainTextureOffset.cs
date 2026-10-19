
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The offset of the main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTextureOffset.html")]
	public sealed class MaterialGetMainTextureOffset : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Get Material Main Texture Offset")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMainTextureOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material, _getMainTextureOffset);
		}
		
		public override void Execute()
		{
			_getMainTextureOffset.Value = _material.Value.mainTextureOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_material} mainTextureOffset -> {_getMainTextureOffset}";
		}
	}
}
