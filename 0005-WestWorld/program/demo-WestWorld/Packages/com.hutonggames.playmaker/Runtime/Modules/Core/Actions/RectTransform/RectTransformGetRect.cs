
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The calculated rectangle in the local space of the Transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-rect.html")]
	public sealed class RectTransformGetRect : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Rect")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getRect);
		}
		
		public override void Execute()
		{
			_getRect.Value = _rectTransform.Value.rect;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} rect -> {_getRect}";
		}
	}
}
