
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Should collision detection be enabled? (By default always enabled).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-detectCollisions.html")]
	public sealed class RigidbodyGetDetectCollisions : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Detect Collisions")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getDetectCollisions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getDetectCollisions);
		}
		
		public override void Execute()
		{
			_getDetectCollisions.Value = _rigidbody.Value.detectCollisions;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} detect collisions -> {_getDetectCollisions}";
		}
	}
}
