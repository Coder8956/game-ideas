
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The width and height of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-size.html")]
	public sealed class RectGetSize : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Size")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _rect.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} size -> {_getSize}";
		}
	}
}
