
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the value of the dynamic friction for a specified contact point in this conta" +
		"ct pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetDynamicFriction" +
		".html")]
	public sealed class ModifiableContactPairSetDynamicFriction : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Dynamic friction coefficient.")]
		[SerializeField]
		private FloatVar _dynamicFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _dynamicFriction);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetDynamicFriction(System.Int32, System.Single);
			_modifiableContactPair.Value.SetDynamicFriction(_i.Value, _dynamicFriction.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Dynamic Friction {_modifiableContactPair} {_i} {_dynamicFriction} ";
		}
	}
}
