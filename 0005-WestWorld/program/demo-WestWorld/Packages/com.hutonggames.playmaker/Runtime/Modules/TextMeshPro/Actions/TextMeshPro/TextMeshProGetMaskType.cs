
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the mask type")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetMaskType : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Mask Type")]
		[SerializeField]
		[WriteOnly]
		private MaskingTypesRef _getMaskType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getMaskType);
		}
		
		public override void Execute()
		{
			_getMaskType.Value = _textMeshPro.Value.maskType;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} mask type -> {_getMaskType}";
		}
	}
}
