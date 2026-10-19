
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the minimum corner of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-min.html")]
	public sealed class RectGetMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Min")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getMin);
		}
		
		public override void Execute()
		{
			_getMin.Value = _rect.Value.min;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} min -> {_getMin}";
		}
	}
}
