
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
	public sealed class RigidbodySetDetectCollisions : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Detect Collisions")]
		[SerializeField]
		private BoolVar _setDetectCollisions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setDetectCollisions);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.detectCollisions = _setDetectCollisions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} detect collisions to {_setDetectCollisions}";
		}
	}
}
