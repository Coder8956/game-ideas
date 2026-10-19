
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the center of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-center.html")]
	public sealed class RectGetCenter : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Center")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _rect.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} center -> {_getCenter}";
		}
	}
}
