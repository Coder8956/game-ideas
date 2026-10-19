
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The Rigidbody\'s collision detection mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-collisionDetectionMode.html")]
	public sealed class RigidbodySetCollisionDetectionMode : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Collision Detection Mode")]
		[SerializeField]
		private CollisionDetectionModeVar _setCollisionDetectionMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setCollisionDetectionMode);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.collisionDetectionMode = _setCollisionDetectionMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} collision detection mode to {_setCollisionDetectionMode}";
		}
	}
}
