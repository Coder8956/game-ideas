
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Function to conveniently set the Font Asset of both Placeholder and Input Field text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetGlobalFontAsset : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Font Asset.")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_FontAssetVar _fontAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.SetGlobalFontAsset(TMPro.TMP_FontAsset);
			_tMP_InputField.Value.SetGlobalFontAsset(_fontAsset.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} global font asset {_fontAsset}";
		}
	}
}
