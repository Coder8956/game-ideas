
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
	public sealed class RectTransformSetAnchorMin : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Anchor Min")]
		[SerializeField]
		private Vector2Var _setAnchorMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setAnchorMin);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.anchorMin = _setAnchorMin.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} anchor min to {_setAnchorMin}";
		}
	}
}
