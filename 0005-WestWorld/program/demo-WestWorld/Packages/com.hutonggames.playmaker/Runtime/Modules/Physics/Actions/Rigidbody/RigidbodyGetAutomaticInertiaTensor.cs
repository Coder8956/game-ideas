
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
	public sealed class RigidbodyGetAutomaticInertiaTensor : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Automatic Inertia Tensor")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutomaticInertiaTensor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getAutomaticInertiaTensor);
		}
		
		public override void Execute()
		{
			_getAutomaticInertiaTensor.Value = _rigidbody.Value.automaticInertiaTensor;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} automatic inertia tensor -> {_getAutomaticInertiaTensor}";
		}
	}
}
