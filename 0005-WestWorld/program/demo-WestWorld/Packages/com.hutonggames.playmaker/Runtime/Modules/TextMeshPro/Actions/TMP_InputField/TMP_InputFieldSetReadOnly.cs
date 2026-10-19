
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is the Input Field readonly?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetReadOnly : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Set TMP_InputField Read Only")]
		[SerializeField]
		private BoolVar _setReadOnly;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _setReadOnly);
		}
		
		public override void Execute()
		{
			_tMP_InputField.Value.readOnly = _setReadOnly.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} read only to {_setReadOnly}";
		}
	}
}
