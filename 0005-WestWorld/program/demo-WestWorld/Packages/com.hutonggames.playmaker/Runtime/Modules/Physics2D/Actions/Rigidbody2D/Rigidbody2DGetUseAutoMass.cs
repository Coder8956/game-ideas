
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
	public sealed class Rigidbody2DGetUseAutoMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Use Auto Mass")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseAutoMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getUseAutoMass);
		}
		
		public override void Execute()
		{
			_getUseAutoMass.Value = _rigidbody2D.Value.useAutoMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} use auto mass -> {_getUseAutoMass}";
		}
	}
}
