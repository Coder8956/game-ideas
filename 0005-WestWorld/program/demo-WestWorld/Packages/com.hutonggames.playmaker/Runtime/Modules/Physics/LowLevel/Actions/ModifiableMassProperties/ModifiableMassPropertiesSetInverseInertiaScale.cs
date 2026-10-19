
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableMassProperties)]
	[ActionDescription("The inverse inertia scaling that the solver should apply to the first body of thi" +
		"s contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableMassProperties-inverseInertiaS" +
		"cale.html")]
	public sealed class ModifiableMassPropertiesSetInverseInertiaScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Set ModifiableMassProperties Inverse Inertia Scale")]
		[SerializeField]
		private FloatVar _setInverseInertiaScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _setInverseInertiaScale);
		}
		
		public override void Execute()
		{
			var value = _modifiableMassProperties.Value;
			value.inverseInertiaScale = _setInverseInertiaScale.Value;
			_modifiableMassProperties.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableMassProperties} Inverse Inertia Scale to {_setInverseInertiaScale}";
		}
	}
}
