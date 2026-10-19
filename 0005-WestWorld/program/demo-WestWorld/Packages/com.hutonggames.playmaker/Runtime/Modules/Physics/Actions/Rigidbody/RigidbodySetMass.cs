
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The mass of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-mass.html")]
	public sealed class RigidbodySetMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Mass")]
		[SerializeField]
		private FloatVar _setMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setMass);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.mass = _setMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} mass to {_setMass}";
		}
	}
}
