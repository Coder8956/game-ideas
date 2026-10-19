
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Sets the Font Asset on both Placeholder and Input child objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetFontAsset : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Font Asset")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_FontAssetVar _setFontAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.fontAsset = _setFontAsset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} font asset to {_setFontAsset}";
		}
	}
}
