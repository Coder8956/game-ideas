
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputButton)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true the first frame the user hits any key, mouse button, or touch. (Read Only)"
		+ Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-anyKeyDown.html")]
	public sealed class InputGetAnyKeyDown : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("Event to send if any key or button pressed.")]
		[SerializeField, OptionalField]
		private EventRef _sendEvent;
		
		[FormerlySerializedAs("_getAnyKeyDown")]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _storeResult;

		[Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
		[SerializeField, OptionalField, WriteOnly]
		private BufferedInputRef _bufferedInput;

		private int _lastTriggeredFrame;
		
		public override void Execute()
		{
			var anyKeyDown = InputShim.AnyKeyDown() || InputShim.AnyTouchDown();
			_storeResult.Value = anyKeyDown;
			if (anyKeyDown && _lastTriggeredFrame != Time.frameCount)
			{
				_lastTriggeredFrame = Time.frameCount;
				SendEvent(_sendEvent);

				if (!_bufferedInput.IsNone)
				{
					_bufferedInput.Record();
				}
			}
		}

		public override string GetSummary() => "If any key down {_storeResult:output} {_sendEvent}" +
		                                       (_bufferedInput.IsNone ?  "" : " (Buffered: {_bufferedInput})");
	}
}
