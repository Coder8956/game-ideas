
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The normalized position in the parent RectTransform that the lower left corner is" +
		" anchored to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-anchorMin.html")]
	public sealed class RectTransformGetAnchorMin : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Anchor Min")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAnchorMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getAnchorMin);
		}
		
		public override void Execute()
		{
			_getAnchorMin.Value = _rectTransform.Value.anchorMin;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} anchor min -> {_getAnchorMin}";
		}
	}
}
