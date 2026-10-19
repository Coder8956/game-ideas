
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
	public sealed class RigidbodyGetMaxDepenetrationVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Max Depenetration Velocity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxDepenetrationVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getMaxDepenetrationVelocity);
		}
		
		public override void Execute()
		{
			_getMaxDepenetrationVelocity.Value = _rigidbody.Value.maxDepenetrationVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} max depenetration velocity -> {_getMaxDepenetrationVelocity}";
		}
	}
}
