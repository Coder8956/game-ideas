
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Sets a named float value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.SetFloat.html")]
	public sealed class MaterialSetFloat : BaseMaterialPropertyAction
	{
		[Tooltip("Float value to set.")]
		[SerializeField]
		private FloatVar _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			
			_material.Value.SetFloat(PropertyId, _value.Value);
		}
		
		public override string GetSummary() => "Set {_material} float {_propertyName} to {_value}";
	}
}
