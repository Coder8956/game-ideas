
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
	public sealed class ModifiableMassPropertiesGetInverseMassScale : BaseAction
	{
		
		[Tooltip("The ModifiableMassProperties")]
		[SerializeField]
		private ModifiableMassPropertiesRef _modifiableMassProperties;
		
		[Tooltip("Get ModifiableMassProperties Inverse Mass Scale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getInverseMassScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableMassProperties, _getInverseMassScale);
		}
		
		public override void Execute()
		{
			_getInverseMassScale.Value = _modifiableMassProperties.Value.inverseMassScale;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableMassProperties} inverseMassScale -> {_getInverseMassScale}";
		}
	}
}
