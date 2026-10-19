
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The normalized position in the parent RectTransform that the upper right corner i" +
		"s anchored to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-anchorMax.html")]
	public sealed class RectTransformGetAnchorMax : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Anchor Max")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAnchorMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getAnchorMax);
		}
		
		public override void Execute()
		{
			_getAnchorMax.Value = _rectTransform.Value.anchorMax;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} anchor max -> {_getAnchorMax}";
		}
	}
}
