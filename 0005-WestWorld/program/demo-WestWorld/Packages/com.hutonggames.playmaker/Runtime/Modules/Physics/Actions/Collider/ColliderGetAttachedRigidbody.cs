
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The rigidbody the collider is attached to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-attachedRigidbody.html")]
	public sealed class ColliderGetAttachedRigidbody : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Attached Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyRef _getAttachedRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getAttachedRigidbody);
		}
		
		public override void Execute()
		{
			_getAttachedRigidbody.Value = _collider.Value.attachedRigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} attached rigidbody -> {_getAttachedRigidbody}";
		}
	}
}
