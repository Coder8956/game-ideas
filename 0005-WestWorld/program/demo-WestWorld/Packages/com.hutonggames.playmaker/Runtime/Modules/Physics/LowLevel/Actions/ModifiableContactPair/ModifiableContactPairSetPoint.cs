
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the location of a particular contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetPoint.html")]
	public sealed class ModifiableContactPairSetPoint : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("The location of a contact point.")]
		[SerializeField]
		private Vector3Var _v;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _v);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetPoint(System.Int32, UnityEngine.Vector3);
			_modifiableContactPair.Value.SetPoint(_i.Value, _v.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Point {_modifiableContactPair} {_i} {_v} ";
		}
	}
}
