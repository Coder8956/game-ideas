
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The offset of the lower left corner of the rectangle relative to the lower left a" +
		"nchor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-offsetMin.html")]
	public sealed class RectTransformSetOffsetMin : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Offset Min")]
		[SerializeField]
		private Vector2Var _setOffsetMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setOffsetMin);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.offsetMin = _setOffsetMin.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} offset min to {_setOffsetMin}";
		}
	}
}
