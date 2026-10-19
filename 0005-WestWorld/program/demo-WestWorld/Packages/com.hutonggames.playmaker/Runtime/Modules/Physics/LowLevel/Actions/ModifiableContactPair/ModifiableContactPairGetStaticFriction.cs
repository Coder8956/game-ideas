
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the static friction coefficient at a particular point of the contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetStaticFriction." +
		"html")]
	public sealed class ModifiableContactPairGetStaticFriction : BaseAction
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
			//UnityEngine.ModifiableContactPair.GetStaticFriction(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetStaticFriction(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Static Friction {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
