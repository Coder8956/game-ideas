
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Get a rect that encloses the XY extents of the bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-size.html")]
	public sealed class BoundsGetEnclosingRect : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get a rect that encloses the XY extents of the bounds.")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getRect);
		}
		
		public override void Execute()
		{
			var bounds = _bounds.Value;
			_getRect.Value = new Rect(bounds.min.x, bounds.min.y, bounds.size.x, bounds.size.y);
		}
		
		public override string GetSummary()
		{
			return "Get Rect that encloses {_bounds} -> {_getRect}";
		}
	}
}
