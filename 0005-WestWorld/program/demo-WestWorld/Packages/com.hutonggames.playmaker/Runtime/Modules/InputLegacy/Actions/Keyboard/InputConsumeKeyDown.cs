using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HutongGames.PlayMaker.FSM;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Keyboard)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true during the frame the user starts pressing down the key identified by " +
	                   "the key KeyCode enum parameter, and consumes that key press for this FSM so other " +
	                   "InputConsumeKeyDown actions in the same FSM won't trigger again until the next frame." +
	                   Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html")]
	public sealed class InputConsumeKeyDown : BaseAction
	{
#if UNITY_6000_5_OR_NEWER
		[Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
		private static ConditionalWeakTable<FsmNode, Dictionary<KeyCode, int>> _consumedFramesByFsm = new();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics()
		{
			_consumedFramesByFsm = new ConditionalWeakTable<FsmNode, Dictionary<KeyCode, int>>();
		}

		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The key to detect.")]
		[SerializeField]
		private KeyCodeVar _key;

		[Tooltip("Event to send if the button is pressed and consumed.")]
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
			var keyDown = InputShim.GetKeyDown(_key.Value);
			var consumed = keyDown
			               && _lastTriggeredFrame != Time.frameCount
			               && TryConsumeKeyDownThisFrame(Fsm, _key.Value, Time.frameCount);

			_storeResult.Value = consumed;

			if (!consumed)
			{
				return;
			}

			_lastTriggeredFrame = Time.frameCount;
			SendEvent(_sendEvent);
		}

		internal static bool TryConsumeKeyDownThisFrame(FsmNode fsm, KeyCode key, int frameCount)
		{
			if (fsm == null)
			{
				return true;
			}

			var consumedFrames = _consumedFramesByFsm.GetOrCreateValue(fsm);
			if (consumedFrames.TryGetValue(key, out var lastConsumedFrame) && lastConsumedFrame == frameCount)
			{
				return false;
			}

			consumedFrames[key] = frameCount;
			return true;
		}

		internal static void ResetConsumedKeyDownsForTests()
		{
			ResetStatics();
		}

		public override string GetSummary() => "If {_key} pressed {_storeResult:output} {_sendEvent}";
	}
}
