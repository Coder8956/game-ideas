
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
	public sealed class RectTransformGetOffsetMin : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Offset Min")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getOffsetMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getOffsetMin);
		}
		
		public override void Execute()
		{
			_getOffsetMin.Value = _rectTransform.Value.offsetMin;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} offset min -> {_getOffsetMin}";
		}
	}
}
