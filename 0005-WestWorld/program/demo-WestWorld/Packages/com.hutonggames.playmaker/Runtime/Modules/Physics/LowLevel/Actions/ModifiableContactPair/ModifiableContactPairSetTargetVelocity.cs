
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the target velocity the solver should aim reaching at a particular contact po" +
		"int in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetTargetVelocity." +
		"html")]
	public sealed class ModifiableContactPairSetTargetVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("The target velocity at a contact point.")]
		[SerializeField]
		private Vector3Var _velocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _velocity);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetTargetVelocity(System.Int32, UnityEngine.Vector3);
			_modifiableContactPair.Value.SetTargetVelocity(_i.Value, _velocity.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Target Velocity {_modifiableContactPair} {_i} {_velocity} ";
		}
	}
}
