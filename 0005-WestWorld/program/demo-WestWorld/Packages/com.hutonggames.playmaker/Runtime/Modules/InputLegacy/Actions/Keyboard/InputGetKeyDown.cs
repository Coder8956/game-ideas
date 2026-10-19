using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Keyboard)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true during the frame the user starts pressing down the key identified by " +
	                   "the key KeyCode enum parameter." + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html")]
	public sealed class InputGetKeyDown : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The key to detect.")]
		[SerializeField]
		private KeyCodeVar _key;
		
		[Tooltip("Event to send if the button is pressed.")]
		[SerializeField, OptionalField]
		private EventRef _sendEvent;
		
		[FormerlySerializedAs("_result")]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _storeResult;

		[Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
		[SerializeField, OptionalField, WriteOnly]
		private BufferedInputRef _bufferedInput;
		
		private int _lastTriggeredFrame;
		
		public override bool CanExecute() => CheckParameters(_key);
		
		public override void Execute()
		{
			var keyDown = InputShim.GetKeyDown(_key.Value);
			_storeResult.Value = keyDown;
			
			if (keyDown && _lastTriggeredFrame != Time.frameCount)
			{
				_lastTriggeredFrame = Time.frameCount;
				SendEvent(_sendEvent);

				if (!_bufferedInput.IsNone)
				{
					_bufferedInput.Record();
				}
			}
		}

		public override string GetSummary() => "If {_key} pressed {_storeResult:output} {_sendEvent}" +
		                                       (_bufferedInput.IsNone ?  "" : " (Buffered: {_bufferedInput})");
	}
}
