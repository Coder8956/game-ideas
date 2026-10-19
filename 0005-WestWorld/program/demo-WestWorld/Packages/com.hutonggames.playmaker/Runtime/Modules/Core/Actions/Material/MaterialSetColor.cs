
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
	public sealed class MaterialSetColor : BaseMaterialPropertyAction
	{
		[DefaultValue("Color.white")]
		[Tooltip("Set Material Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_setColor);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetColor(PropertyId, _setColor.Value);
		}
		
		public override string GetSummary() => "Set {_material} float {_propertyName} to {_setColor}";
	}
}
