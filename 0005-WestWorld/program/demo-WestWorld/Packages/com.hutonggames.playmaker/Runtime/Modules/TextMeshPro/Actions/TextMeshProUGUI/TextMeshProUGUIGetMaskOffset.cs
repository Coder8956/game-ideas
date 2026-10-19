
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Get the masking offset from the bounds of the object")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetMaskOffset : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Get TextMeshProUGUI Mask Offset")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getMaskOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _getMaskOffset);
		}
		
		public override void Execute()
		{
			_getMaskOffset.Value = _textMeshProUGUI.Value.maskOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} mask offset -> {_getMaskOffset}";
		}
	}
}
