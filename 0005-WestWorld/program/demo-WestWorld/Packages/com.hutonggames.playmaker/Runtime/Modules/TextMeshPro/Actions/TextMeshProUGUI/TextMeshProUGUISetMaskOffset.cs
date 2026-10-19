
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Set the masking offset from the bounds of the object")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUISetMaskOffset : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Set TextMeshProUGUI Mask Offset")]
		[SerializeField]
		private Vector4Var _setMaskOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _setMaskOffset);
		}
		
		public override void Execute()
		{
			_textMeshProUGUI.Value.maskOffset = _setMaskOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshProUGUI} mask offset to {_setMaskOffset}";
		}
	}
}
