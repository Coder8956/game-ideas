
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("The Unity Event to call when editing has ended.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldOnEndEdit__UnityEvent : BaseAction
	{
		
		[Tooltip("The InputField")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Set InputField On End Edit")]
		[SerializeField]
		private InputField_EndEditEventVar _setOnEndEdit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _setOnEndEdit);
		}
		
		public override void Execute()
		{
			_inputField.Value.onEndEdit = _setOnEndEdit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_inputField} on end edit to {_setOnEndEdit}";
		}
	}
}
