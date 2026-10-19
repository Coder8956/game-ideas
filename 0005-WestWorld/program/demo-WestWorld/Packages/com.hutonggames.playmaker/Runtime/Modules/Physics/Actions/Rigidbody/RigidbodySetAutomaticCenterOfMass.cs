
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Whether or not to calculate the center of mass automatically.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-automaticCenterOfMass.html")]
	public sealed class RigidbodySetAutomaticCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Automatic Center Of Mass")]
		[SerializeField]
		private BoolVar _setAutomaticCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setAutomaticCenterOfMass);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.automaticCenterOfMass = _setAutomaticCenterOfMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} automatic center of mass to {_setAutomaticCenterOfMass}";
		}
	}
}
