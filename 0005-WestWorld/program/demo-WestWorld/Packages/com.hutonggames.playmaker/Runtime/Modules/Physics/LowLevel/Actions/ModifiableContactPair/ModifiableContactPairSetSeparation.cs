
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the separation value at a particular contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetSeparation.html" +
		"")]
	public sealed class ModifiableContactPairSetSeparation : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("The separation at a contact point.")]
		[SerializeField]
		private FloatVar _separation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _separation);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetSeparation(System.Int32, System.Single);
			_modifiableContactPair.Value.SetSeparation(_i.Value, _separation.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Separation {_modifiableContactPair} {_i} {_separation} ";
		}
	}
}
