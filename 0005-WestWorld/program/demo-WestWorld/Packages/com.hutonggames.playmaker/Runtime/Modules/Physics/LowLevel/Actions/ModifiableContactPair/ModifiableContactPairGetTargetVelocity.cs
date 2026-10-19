
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the target velocity the solver should aim reaching at a particular contact po" +
		"int in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetTargetVelocity." +
		"html")]
	public sealed class ModifiableContactPairGetTargetVelocity : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.GetTargetVelocity(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetTargetVelocity(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Target Velocity {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
