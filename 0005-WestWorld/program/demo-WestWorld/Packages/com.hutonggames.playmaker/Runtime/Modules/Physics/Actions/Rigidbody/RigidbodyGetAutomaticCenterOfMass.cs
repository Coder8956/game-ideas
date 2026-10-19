
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
	public sealed class RigidbodyGetAutomaticCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Automatic Center Of Mass")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutomaticCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getAutomaticCenterOfMass);
		}
		
		public override void Execute()
		{
			_getAutomaticCenterOfMass.Value = _rigidbody.Value.automaticCenterOfMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} automatic center of mass -> {_getAutomaticCenterOfMass}";
		}
	}
}
