
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
	public sealed class RectTransformGetOffsetMax : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Offset Max")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getOffsetMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getOffsetMax);
		}
		
		public override void Execute()
		{
			_getOffsetMax.Value = _rectTransform.Value.offsetMax;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} offset max -> {_getOffsetMax}";
		}
	}
}
