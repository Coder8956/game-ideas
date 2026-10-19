
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
	public sealed class ModifiableMassPropertiesGetOtherInverseMassScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Get ModifiableMassProperties Other Inverse Mass Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getOtherInverseMassScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _getOtherInverseMassScale);
		}
		
		public override void Execute()
		{
			_getOtherInverseMassScale.Value = _modifiableMassProperties.Value.otherInverseMassScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableMassProperties} otherInverseMassScale -> {_getOtherInverseMassScale}";
		}
	}
}
