
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the restitution value for the specified contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetBounciness.html" +
		"")]
	public sealed class ModifiableContactPairSetBounciness : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Bounciness value for the specified contact point.")]
		[SerializeField]
		private FloatVar _bounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _bounciness);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetBounciness(System.Int32, System.Single);
			_modifiableContactPair.Value.SetBounciness(_i.Value, _bounciness.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Bounciness {_modifiableContactPair} {_i} {_bounciness} ";
		}
	}
}
