
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableMassProperties)]
	[ActionDescription("The inverse mass scaling that the solver should apply to the first body of this c" +
		"ontact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableMassProperties-inverseMassScal" +
		"e.html")]
	public sealed class ModifiableMassPropertiesSetInverseMassScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Set ModifiableMassProperties Inverse Mass Scale")]
		[SerializeField]
		private FloatVar _setInverseMassScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _setInverseMassScale);
		}
		
		public override void Execute()
		{
			var value = _modifiableMassProperties.Value;
			value.inverseMassScale = _setInverseMassScale.Value;
			_modifiableMassProperties.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_modifiableMassProperties} Inverse Mass Scale to {_setInverseMassScale}";
		}
	}
}
