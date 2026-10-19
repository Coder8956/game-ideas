
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Determines if the whole text will be selected when focused.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetOnFocusSelectAll : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField On Focus Select All")]
		[SerializeField]
		private BoolVar _setOnFocusSelectAll;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setOnFocusSelectAll);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.onFocusSelectAll = _setOnFocusSelectAll.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} on focus select all to {_setOnFocusSelectAll}";
		}
	}
}
