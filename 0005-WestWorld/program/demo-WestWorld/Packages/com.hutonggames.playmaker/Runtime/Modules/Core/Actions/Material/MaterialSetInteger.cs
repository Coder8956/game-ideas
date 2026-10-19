
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets a named integer value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetInteger.html")]
	public sealed class MaterialSetInteger : BaseMaterialPropertyAction
	{
		[Tooltip("Integer value to set.")]
		[SerializeField]
		private IntegerVar _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetInteger(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} integer {_propertyName} to {_value}";
	}
}
