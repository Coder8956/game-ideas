
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("The amount of the contact points generated for this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair-contactCount.html")]
	public sealed class ModifiableContactPairGetContactCount : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Get ModifiableContactPair Contact Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getContactCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _getContactCount);
		}
		
		public override void Execute()
		{
			_getContactCount.Value = _modifiableContactPair.Value.contactCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_modifiableContactPair} contactCount -> {_getContactCount}";
		}
	}
}
