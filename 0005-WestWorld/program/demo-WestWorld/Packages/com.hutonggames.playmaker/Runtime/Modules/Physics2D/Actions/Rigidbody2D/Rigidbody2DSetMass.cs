
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Mass of the Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-mass.html")]
	public sealed class Rigidbody2DSetMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Mass")]
		[SerializeField]
		private FloatVar _setMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setMass);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.mass = _setMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} mass to {_setMass}";
		}
	}
}
