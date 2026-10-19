
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Should the total rigid-body mass be automatically calculated from the Collider2D." +
		"density of attached colliders?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-useAutoMass.html")]
	public sealed class Rigidbody2DSetUseAutoMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Use Auto Mass")]
		[SerializeField]
		private BoolVar _setUseAutoMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setUseAutoMass);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.useAutoMass = _setUseAutoMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} use auto mass to {_setUseAutoMass}";
		}
	}
}
