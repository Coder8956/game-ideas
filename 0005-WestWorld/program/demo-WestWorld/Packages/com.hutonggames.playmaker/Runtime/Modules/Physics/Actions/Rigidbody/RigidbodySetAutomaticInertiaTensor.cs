
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Whether or not to calculate the inertia tensor automatically.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-automaticInertiaTensor.html")]
	public sealed class RigidbodySetAutomaticInertiaTensor : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Automatic Inertia Tensor")]
		[SerializeField]
		private BoolVar _setAutomaticInertiaTensor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setAutomaticInertiaTensor);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.automaticInertiaTensor = _setAutomaticInertiaTensor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} automatic inertia tensor to {_setAutomaticInertiaTensor}";
		}
	}
}
