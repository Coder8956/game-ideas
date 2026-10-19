
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the maximum corner of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-max.html")]
	public sealed class RectGetMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Max")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getMax);
		}
		
		public override void Execute()
		{
			_getMax.Value = _rect.Value.max;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} max -> {_getMax}";
		}
	}
}
