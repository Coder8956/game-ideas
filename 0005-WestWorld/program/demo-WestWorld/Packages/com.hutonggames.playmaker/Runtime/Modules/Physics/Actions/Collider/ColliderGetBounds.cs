
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The world space bounding volume of the collider (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-bounds.html")]
	public sealed class ColliderGetBounds : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getBounds);
		}
		
		public override void Execute()
		{
			_getBounds.Value = _collider.Value.bounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} bounds -> {_getBounds}";
		}
	}
}
