
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the value of the dynamic friction for a specified contact point in this conta" +
		"ct pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetDynamicFriction" +
		".html")]
	public sealed class ModifiableContactPairGetDynamicFriction : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.GetDynamicFriction(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetDynamicFriction(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Dynamic Friction {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
