using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Sends an event when user submits from a UI InputField component." +
	                   "\nThis only fires if the user press Enter, not when field looses focus or user escaped the field.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldOnSubmit : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;

		[Tooltip("Event to send when the user submits the input field.")]
		[SerializeField]
		private EventRef _event;

		[Tooltip("Get the input field text value.")]
		[SerializeField, WriteOnly]
		private StringRef _text;
		
		public override bool CanExecute() => CheckParameters(_tMP_InputField, _event, _text);

		public override void OnStart()
		{
			_tMP_InputField.Value.onSubmit.AddListener(DoOnSubmit);
		}
		
		public override void OnStop()
		{
			_tMP_InputField.Value.onSubmit.RemoveListener(DoOnSubmit);
		}

		private void DoOnSubmit(string text)
		{
			_text.Value = text;
			SendEvent(_event);
		}
		
		public override string GetSummary() => "Send {_event} when {_tMP_InputField} is submitted -> {_text}";
	}
}
