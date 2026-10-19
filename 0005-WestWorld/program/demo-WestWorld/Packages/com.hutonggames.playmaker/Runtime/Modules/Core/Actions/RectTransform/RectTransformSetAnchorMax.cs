
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
	public sealed class RectTransformSetAnchorMax : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Anchor Max")]
		[SerializeField]
		private Vector2Var _setAnchorMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setAnchorMax);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.anchorMax = _setAnchorMax.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} anchor max to {_setAnchorMax}";
		}
	}
}
