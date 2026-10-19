
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_InputField)]
	[ActionDescription("Rebuild the input fields geometry. (caret and highlight).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
	public sealed class InputFieldRebuild : BaseAction
	{
		
		[Tooltip("The InputField.")]
		[SerializeField]
		private InputFieldVar _inputField;
		
		[Tooltip("Update.")]
		[SerializeField]
		private CanvasUpdateVar _update;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputField, _update);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.InputField.Rebuild(UnityEngine.UI.CanvasUpdate);
			_inputField.Value.Rebuild(_update.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_inputField} {_update}";
		}
	}
}
