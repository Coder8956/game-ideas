
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
	public sealed class ModifiableMassPropertiesGetOtherInverseInertiaScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Get ModifiableMassProperties Other Inverse Inertia Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getOtherInverseInertiaScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _getOtherInverseInertiaScale);
		}
		
		public override void Execute()
		{
			_getOtherInverseInertiaScale.Value = _modifiableMassProperties.Value.otherInverseInertiaScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableMassProperties} otherInverseInertiaScale -> {_getOtherInverseInertiaScale}";
		}
	}
}
