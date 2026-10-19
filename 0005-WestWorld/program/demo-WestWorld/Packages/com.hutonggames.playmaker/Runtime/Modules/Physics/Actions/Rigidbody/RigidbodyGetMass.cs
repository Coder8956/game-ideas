
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
	public sealed class RigidbodyGetMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Mass")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getMass);
		}
		
		public override void Execute()
		{
			_getMass.Value = _rigidbody.Value.mass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} mass -> {_getMass}";
		}
	}
}
