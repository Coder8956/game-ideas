
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the maximum impulse that the solver can apply at a particular contact point i" +
		"n this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetMaxImpulse.html" +
		"")]
	public sealed class ModifiableContactPairSetMaxImpulse : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("The maximum impulse that can be applied.")]
		[SerializeField]
		private FloatVar _value;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _value);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetMaxImpulse(System.Int32, System.Single);
			_modifiableContactPair.Value.SetMaxImpulse(_i.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Max Impulse {_modifiableContactPair} {_i} {_value} ";
		}
	}
}
