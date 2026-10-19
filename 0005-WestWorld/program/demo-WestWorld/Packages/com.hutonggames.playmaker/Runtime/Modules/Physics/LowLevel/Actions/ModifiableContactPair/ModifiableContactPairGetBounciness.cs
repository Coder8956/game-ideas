
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the restitution value for the specified contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetBounciness.html" +
		"")]
	public sealed class ModifiableContactPairGetBounciness : BaseAction
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
			//UnityEngine.ModifiableContactPair.GetBounciness(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetBounciness(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Bounciness {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
