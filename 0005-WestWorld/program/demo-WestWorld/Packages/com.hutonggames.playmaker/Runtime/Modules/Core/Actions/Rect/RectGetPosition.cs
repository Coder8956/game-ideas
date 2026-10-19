
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The X and Y position of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-position.html")]
	public sealed class RectGetPosition : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getPosition);
		}
		
		public override void Execute()
		{
			_getPosition.Value = _rect.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} position -> {_getPosition}";
		}
	}
}
