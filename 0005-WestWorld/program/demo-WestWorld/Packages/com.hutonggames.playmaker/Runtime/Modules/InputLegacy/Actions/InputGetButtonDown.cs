using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputButton)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true during the frame the user pressed down the virtual button " +
	                   "identified by buttonName." + Strings.LimitedButtonSupport)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html")]
	public sealed class InputGetButtonDown : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("Button Name.")]
		[SerializeField, DefaultValue("Fire1")]
		private StringVar _buttonName;

		[Tooltip("Event to send if the button is pressed.")]
		[SerializeField, OptionalField]
		private EventRef _sendEvent;
		
		[FormerlySerializedAs("_result")]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, OptionalField, WriteOnly]
		private BoolRef _storeResult;
		
		[Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
		[SerializeField, OptionalField, WriteOnly]
		private BufferedInputRef _bufferedInput;
		
		private int _lastTriggeredFrame;
		
		public override bool CanExecute() => CheckParameters(_buttonName);

		public override void Execute()
		{
			var pressed = InputShim.GetButtonDown(_buttonName.Value);
			_storeResult.Value = pressed;
			
			if (pressed && _lastTriggeredFrame != Time.frameCount)
			{
				_lastTriggeredFrame = Time.frameCount;
				
				SendEvent(_sendEvent);

				if (!_bufferedInput.IsNone)
				{
					_bufferedInput.Record();
				}
			}
		}

		public override string GetSummary() => "If {_buttonName} pressed {_storeResult:output} {_sendEvent}" +
		                                       (_bufferedInput.IsNone ?  "" : " (Buffered: {_bufferedInput})");
	}
}
