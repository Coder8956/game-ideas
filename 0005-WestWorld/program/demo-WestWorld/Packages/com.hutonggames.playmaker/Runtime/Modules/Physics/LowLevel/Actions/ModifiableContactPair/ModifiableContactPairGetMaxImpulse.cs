
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the maximum impulse that the solver can apply at a particular contact point i" +
		"n this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetMaxImpulse.html" +
		"")]
	public sealed class ModifiableContactPairGetMaxImpulse : BaseAction
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
			//UnityEngine.ModifiableContactPair.GetMaxImpulse(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetMaxImpulse(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Max Impulse {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
