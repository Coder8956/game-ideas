
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Mask)]
	[ActionDescription("Cached RectTransform.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Mask.html")]
	public sealed class MaskGetRectTransform : BaseAction
	{
		
		[Tooltip("The Mask")]
		[SerializeField]
		private MaskVar _mask;
		
		[Tooltip("Get Mask Rect Transform")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getRectTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_mask, _getRectTransform);
		}
		
		public override void Execute()
		{
			_getRectTransform.Value = _mask.Value.rectTransform;
		}
		
		public override string GetSummary()
		{
			return "Get {_mask} rect transform -> {_getRectTransform}";
		}
	}
}
