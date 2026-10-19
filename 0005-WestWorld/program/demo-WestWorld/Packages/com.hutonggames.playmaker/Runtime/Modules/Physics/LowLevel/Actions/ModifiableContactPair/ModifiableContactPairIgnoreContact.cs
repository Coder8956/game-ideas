
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Ignore the specified contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.IgnoreContact.html")]
	public sealed class ModifiableContactPairIgnoreContact : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _index;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _index);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.IgnoreContact(System.Int32);
			_modifiableContactPair.Value.IgnoreContact(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Ignore Contact {_modifiableContactPair} {_index} ";
		}
	}
}
