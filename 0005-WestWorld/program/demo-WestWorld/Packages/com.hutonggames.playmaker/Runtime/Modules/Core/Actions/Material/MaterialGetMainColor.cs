
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("The main color of the Material.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-color.html")]
	public sealed class MaterialGetMainColor : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Get Material Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getColor;
		
		public override bool CanExecute() => CheckParameters(_material, _getColor);

		public override void Execute() => _getColor.Value = _material.Value.color;

		public override string GetSummary() => "Get {_material} color -> {_getColor}";
	}
}
