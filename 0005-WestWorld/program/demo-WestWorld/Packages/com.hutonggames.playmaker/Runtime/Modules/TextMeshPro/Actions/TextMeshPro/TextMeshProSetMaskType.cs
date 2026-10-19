
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the mask type")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProSetMaskType : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Set TextMeshPro Mask Type")]
		[SerializeField]
		private MaskingTypesVar _setMaskType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _setMaskType);
		}
		
		public override void Execute()
		{
			_textMeshPro.Value.maskType = _setMaskType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} mask type to {_setMaskType}";
		}
	}
}
