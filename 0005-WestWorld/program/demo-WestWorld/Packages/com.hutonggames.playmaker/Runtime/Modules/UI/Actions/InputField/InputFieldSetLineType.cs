
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The LineType used by the InputField.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldSetLineType : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField Line Type")]
		[SerializeField]
		private InputField_LineTypeVar _setLineType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setLineType);
		}
		
		public override void Execute()
		{
			_inputField.Value.lineType = _setLineType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} line type to {_setLineType}";
		}
	}
}
