
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("The Font Asset on both Placeholder and Input child objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetFontAsset : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Font Asset")]
		[SerializeField]
		[WriteOnly]
		private TMP_FontAssetRef _getFontAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getFontAsset);
		}
		
		public override void Execute()
		{
			_getFontAsset.Value = _tMP_InputField.Value.fontAsset;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} font asset -> {_getFontAsset}";
		}
	}
}
