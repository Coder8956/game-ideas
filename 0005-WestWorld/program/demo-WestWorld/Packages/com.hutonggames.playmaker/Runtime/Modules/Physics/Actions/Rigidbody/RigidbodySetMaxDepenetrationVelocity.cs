
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Maximum velocity of a rigidbody when moving out of penetrating state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-maxDepenetrationVelocity.html")]
	public sealed class RigidbodySetMaxDepenetrationVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Max Depenetration Velocity")]
		[SerializeField]
		private FloatVar _setMaxDepenetrationVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setMaxDepenetrationVelocity);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.maxDepenetrationVelocity = _setMaxDepenetrationVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} max depenetration velocity to {_setMaxDepenetrationVelocity}";
		}
	}
}
