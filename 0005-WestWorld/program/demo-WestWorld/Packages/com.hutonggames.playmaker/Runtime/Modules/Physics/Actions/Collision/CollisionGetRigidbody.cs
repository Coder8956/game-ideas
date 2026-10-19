
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("The Rigidbody we hit (Read Only). This is null if the object we hit is a collider" +
		" with no rigidbody attached.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-rigidbody.html")]
	public sealed class CollisionGetRigidbody : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyRef _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _collision.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} rigidbody -> {_getRigidbody}";
		}
	}
}
