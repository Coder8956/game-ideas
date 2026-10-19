
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets a named vector value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetVector.html")]
	public sealed class MaterialSetVector : BaseMaterialPropertyAction
	{
		[Tooltip("Vector value to set.")]
		[SerializeField]
		private Vector4Var _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetVector(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} Vector {_propertyName} to {_value}";
	}
}
