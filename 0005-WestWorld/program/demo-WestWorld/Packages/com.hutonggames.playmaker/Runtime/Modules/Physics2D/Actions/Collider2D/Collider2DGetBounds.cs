
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The world space bounding area of the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-bounds.html")]
	public sealed class Collider2DGetBounds : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getBounds);
		}
		
		public override void Execute()
		{
			_getBounds.Value = _collider2D.Value.bounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} bounds -> {_getBounds}";
		}
	}
}
