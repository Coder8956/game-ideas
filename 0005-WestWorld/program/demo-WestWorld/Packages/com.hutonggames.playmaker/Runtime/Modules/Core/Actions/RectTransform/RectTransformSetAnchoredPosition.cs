
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
	public sealed class RectTransformSetAnchoredPosition : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Anchored Position")]
		[SerializeField]
		private Vector2Var _setAnchoredPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setAnchoredPosition);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.anchoredPosition = _setAnchoredPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} anchored position to {_setAnchoredPosition}";
		}
	}
}
