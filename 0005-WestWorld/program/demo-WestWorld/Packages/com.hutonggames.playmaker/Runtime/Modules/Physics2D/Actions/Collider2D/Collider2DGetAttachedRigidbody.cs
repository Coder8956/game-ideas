
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The Rigidbody2D attached to the Collider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-attachedRigidbody.html")]
	public sealed class Collider2DGetAttachedRigidbody : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Attached Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DVar _getAttachedRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getAttachedRigidbody);
		}
		
		public override void Execute()
		{
			_getAttachedRigidbody.Value = _collider2D.Value.attachedRigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} attached rigidbody -> {_getAttachedRigidbody}";
		}
	}
}
