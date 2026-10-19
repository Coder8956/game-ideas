
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The offset of the upper right corner of the rectangle relative to the upper right" +
		" anchor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-offsetMax.html")]
	public sealed class RectTransformSetOffsetMax : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Set RectTransform Offset Max")]
		[SerializeField]
		private Vector2Var _setOffsetMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _setOffsetMax);
		}
		
		public override void Execute()
		{
			_rectTransform.Value.offsetMax = _setOffsetMax.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} offset max to {_setOffsetMax}";
		}
	}
}
