
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ConvertibleGroup("MaterialSetColor")]
	[ActionDescription("The main color of the Material.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material-color.html")]
	public sealed class MaterialSetMainColor : BaseAction
	{
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[DefaultValue("Color.white")]
		[Tooltip("Set Material Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute() => CheckParameters(_material, _setColor);

		public override void Execute() => _material.Value.color = _setColor.Value;

		public override string GetSummary() => "Set {_material} color to {_setColor}";
	}
}
