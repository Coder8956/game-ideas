
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableMassProperties)]
	[ActionDescription("The inverse inertia scaling that the solver should apply to the second body of th" +
		"is contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableMassProperties-otherInverseIne" +
		"rtiaScale.html")]
	public sealed class ModifiableMassPropertiesSetOtherInverseInertiaScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Set ModifiableMassProperties Other Inverse Inertia Scale")]
		[SerializeField]
		private FloatVar _setOtherInverseInertiaScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _setOtherInverseInertiaScale);
		}
		
		public override void Execute()
		{
			var value = _modifiableMassProperties.Value;
			value.otherInverseInertiaScale = _setOtherInverseInertiaScale.Value;
			_modifiableMassProperties.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableMassProperties} Other Inverse Inertia Scale to {_setOtherInverseInertiaScale}";
		}
	}
}
