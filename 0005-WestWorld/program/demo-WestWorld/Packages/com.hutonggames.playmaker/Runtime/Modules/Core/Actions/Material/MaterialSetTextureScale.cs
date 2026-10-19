
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets the placement scale of texture propertyName.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetTextureScale.html")]
	public sealed class MaterialSetTextureScale : BaseMaterialPropertyAction
	{
		[Tooltip("Texture placement scale.")]
		[SerializeField]
		private Vector2Var _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetTextureScale(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} texture scale {_propertyName} to {_value}";
	}
}
