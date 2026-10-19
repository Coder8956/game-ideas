
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The position of the pivot of this RectTransform relative to the anchor reference " +
		"point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition.html")]
	public sealed class RectTransformGetAnchoredPosition : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Anchored Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAnchoredPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getAnchoredPosition);
		}
		
		public override void Execute()
		{
			_getAnchoredPosition.Value = _rectTransform.Value.anchoredPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} anchored position -> {_getAnchoredPosition}";
		}
	}
}
