
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Should kinematickinematic and kinematicstatic collisions be allowed?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-useFullKinematicContacts.html")]
	public sealed class Rigidbody2DGetUseFullKinematicContacts : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Use Full Kinematic Contacts")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseFullKinematicContacts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getUseFullKinematicContacts);
		}
		
		public override void Execute()
		{
			_getUseFullKinematicContacts.Value = _rigidbody2D.Value.useFullKinematicContacts;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} use full kinematic contacts -> {_getUseFullKinematicContacts}";
		}
	}
}
