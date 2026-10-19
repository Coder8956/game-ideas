
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the static friction coefficient at a particular point of the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetStaticFriction." +
		"html")]
	public sealed class ModifiableContactPairSetStaticFriction : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("The static friction coefficient at a contact point.")]
		[SerializeField]
		private FloatVar _staticFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _staticFriction);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetStaticFriction(System.Int32, System.Single);
			_modifiableContactPair.Value.SetStaticFriction(_i.Value, _staticFriction.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Static Friction {_modifiableContactPair} {_i} {_staticFriction} ";
		}
	}
}
