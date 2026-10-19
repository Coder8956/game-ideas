
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The Rigidbody\'s collision detection mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-collisionDetectionMode.html")]
	public sealed class RigidbodyGetCollisionDetectionMode : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Collision Detection Mode")]
		[SerializeField]
		[WriteOnly]
		private CollisionDetectionModeRef _getCollisionDetectionMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getCollisionDetectionMode);
		}
		
		public override void Execute()
		{
			_getCollisionDetectionMode.Value = _rigidbody.Value.collisionDetectionMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} collision detection mode -> {_getCollisionDetectionMode}";
		}
	}
}
