
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets the placement offset of a given texture. The name parameter is defined in the shader. " +
	                   "This method creates a new Material instance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetTextureOffset.html")]
	public sealed class MaterialSetTextureOffset : BaseMaterialPropertyAction
	{
		[Tooltip("Texture placement offset.")]
		[SerializeField]
		private Vector2Var _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetTextureOffset(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} texture offset {_propertyName} to {_value}";
	}
}
