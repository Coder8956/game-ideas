
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPair)]
	[ActionDescription("Get the index of a face that a particular contact point belongs to in this Contac" +
		"tPairPoint.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPair.GetContactPointFaceIndex.htm" +
		"l")]
	public sealed class ContactPairGetContactPointFaceIndex : BaseAction
	{
		
		[Tooltip("The ContactPair.")]
		[SerializeField]
		private ContactPairRef _contactPair;
		
		[Tooltip("The ContactPairPoint index.")]
		[SerializeField]
		private IntegerVar _contactIndex;
		
		[Tooltip("Store the result in Unsigned Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private UIntRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPair, _contactIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactPair.GetContactPointFaceIndex(System.Int32);
			_result.Value = _contactPair.Value.GetContactPointFaceIndex(_contactIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Contact Point Face Index {_contactPair} {_contactIndex} -> {_result}";
		}
	}
}
