
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Should kinematickinematic and kinematicstatic collisions be allowed?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-useFullKinematicContacts.htm" +
		"l")]
	public sealed class Rigidbody2DSetUseFullKinematicContacts : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Use Full Kinematic Contacts")]
		[SerializeField]
		private BoolVar _setUseFullKinematicContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setUseFullKinematicContacts);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.useFullKinematicContacts = _setUseFullKinematicContacts.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} use full kinematic contacts to {_setUseFullKinematicContacts}";
		}
	}
}
