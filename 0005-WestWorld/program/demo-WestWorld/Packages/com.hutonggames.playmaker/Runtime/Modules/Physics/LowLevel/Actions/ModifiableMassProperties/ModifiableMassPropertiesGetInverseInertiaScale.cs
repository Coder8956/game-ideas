
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
	public sealed class ModifiableMassPropertiesGetInverseInertiaScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Get ModifiableMassProperties Inverse Inertia Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getInverseInertiaScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _getInverseInertiaScale);
		}
		
		public override void Execute()
		{
			_getInverseInertiaScale.Value = _modifiableMassProperties.Value.inverseInertiaScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableMassProperties} inverseInertiaScale -> {_getInverseInertiaScale}";
		}
	}
}
