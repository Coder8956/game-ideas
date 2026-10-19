
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Set the normal at a particular contact point in this contact pair.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.SetNormal.html")]
	public sealed class ModifiableContactPairSetNormal : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Normal at the contact point.")]
		[SerializeField]
		private Vector3Var _normal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _normal);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.SetNormal(System.Int32, UnityEngine.Vector3);
			_modifiableContactPair.Value.SetNormal(_i.Value, _normal.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Normal {_modifiableContactPair} {_i} {_normal} ";
		}
	}
}
