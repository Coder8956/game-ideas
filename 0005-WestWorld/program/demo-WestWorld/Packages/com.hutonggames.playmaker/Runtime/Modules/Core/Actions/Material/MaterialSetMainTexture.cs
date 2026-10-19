
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The main texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-mainTexture.html")]
	public sealed class MaterialSetMainTexture : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Set Material Main Texture")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _setMainTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_material);
		}
		
		public override void Execute()
		{
			_material.Value.mainTexture = _setMainTexture.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_material} Main Texture to {_setMainTexture}";
		}
	}
}
