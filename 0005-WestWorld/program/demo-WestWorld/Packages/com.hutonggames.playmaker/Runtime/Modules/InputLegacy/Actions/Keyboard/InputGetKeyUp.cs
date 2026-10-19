using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Keyboard)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true during the frame the user releases the key identified by the key Key" +
		"Code enum parameter." + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetKeyUp.html")]
	public sealed class InputGetKeyUp : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The key to detect.")]
		[SerializeField]
		private KeyCodeVar _key;
		
		[Tooltip("Event to send if the button is released.")]
		[SerializeField, OptionalField]
		private EventRef _sendEvent;
		
		[FormerlySerializedAs("_result")]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _storeResult;
		
		private int _lastTriggeredFrame;
		
		public override bool CanExecute() => CheckParameters(_key);
		
		public override void Execute()
		{
			var keyUp = InputShim.GetKeyUp(_key.Value);
			_storeResult.Value = keyUp;
			
			if (keyUp && _lastTriggeredFrame != Time.frameCount)
			{
				_lastTriggeredFrame = Time.frameCount;
				SendEvent(_sendEvent);
			}
		}

		public override string GetSummary() => "If {_key} released {_storeResult:output} {_sendEvent}";
	}
}
