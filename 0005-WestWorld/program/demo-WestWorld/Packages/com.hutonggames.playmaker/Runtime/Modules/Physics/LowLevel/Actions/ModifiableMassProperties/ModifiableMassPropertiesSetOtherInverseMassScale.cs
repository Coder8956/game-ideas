
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableMassProperties)]
	[ActionDescription("The inverse mass scaling that the solver should apply to the second body of this " +
		"contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableMassProperties-otherInverseMas" +
		"sScale.html")]
	public sealed class ModifiableMassPropertiesSetOtherInverseMassScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Set ModifiableMassProperties Other Inverse Mass Scale")]
		[SerializeField]
		private FloatVar _setOtherInverseMassScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _setOtherInverseMassScale);
		}
		
		public override void Execute()
		{
			var value = _modifiableMassProperties.Value;
			value.otherInverseMassScale = _setOtherInverseMassScale.Value;
			_modifiableMassProperties.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableMassProperties} Other Inverse Mass Scale to {_setOtherInverseMassScale}";
		}
	}
}
