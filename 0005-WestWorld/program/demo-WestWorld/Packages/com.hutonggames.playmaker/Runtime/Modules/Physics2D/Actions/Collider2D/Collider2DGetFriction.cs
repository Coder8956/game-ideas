
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Get the friction used by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-friction.html")]
	public sealed class Collider2DGetFriction : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Friction")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getFriction);
		}
		
		public override void Execute()
		{
			_getFriction.Value = _collider2D.Value.friction;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} friction -> {_getFriction}";
		}
	}
}
