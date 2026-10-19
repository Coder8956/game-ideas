
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Is the Input Field readonly?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetReadOnly : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Read Only")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getReadOnly;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getReadOnly);
		}
		
		public override void Execute()
		{
			_getReadOnly.Value = _tMP_InputField.Value.readOnly;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} read only -> {_getReadOnly}";
		}
	}
}
