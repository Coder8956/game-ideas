
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the normal at a particular contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetNormal.html")]
	public sealed class ModifiableContactPairGetNormal : BaseAction
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
			//UnityEngine.ModifiableContactPair.GetNormal(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetNormal(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Normal {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
