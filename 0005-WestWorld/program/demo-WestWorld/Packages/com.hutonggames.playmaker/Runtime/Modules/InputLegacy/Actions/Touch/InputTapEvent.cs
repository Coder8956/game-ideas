
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Sends an event when a touch tap is detected.")]
	public sealed class InputTapEvent : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		[Tooltip("Number of touches needed to detect tap. 1 = single finger, 2 = two fingers, etc.")]
		[SerializeField, DefaultValue(1)]
		private IntegerVar _fingerCount;

		[Tooltip("Number of taps required to send the event. 1 = single tap, 2 = double tap, etc.")]
		[SerializeField, DefaultValue(1)]
		private IntegerVar _requiredTapCount;
		
		[OptionalField]
		[Tooltip("Event to send when tap detected.")]
		[SerializeField]
		private EventRef _tapEvent;
		
		private int _highestTouchCount;
		private int _lastTriggeredFrame;
		
		public override bool CanExecute() => CheckParameters(_fingerCount, _requiredTapCount);

		public override void Execute()
		{
			if (Input.touchCount <= 0)
			{
				_highestTouchCount = 0;
				return;
			}
			
			// We use the highest touch count to check against the required finger count.
			// This is not super accurate, but the gesture is quick, and it seems "good enough."
			// Also, a more accurate algorithm, that is more pedantic about each finger's
			// down/up/distance measurement might actually miss gestures and feel worse.
			// Anyway, this method needs user testing...
			
			if (Input.touchCount > _highestTouchCount)
			{
				_highestTouchCount = Input.touchCount;
			}

			var touch = Input.touches[0];
			if (touch.phase == TouchPhase.Ended 
			    && touch.tapCount >= _requiredTapCount.Value 
			    && _highestTouchCount == _fingerCount.Value
			    && Time.frameCount != _lastTriggeredFrame) // avoid infinite loops!
			{
				_lastTriggeredFrame = Time.frameCount;
				if (_tapEvent.IsSet) SendEvent(_tapEvent);
			}
		}
		
		public override string GetSummary() => 
			(_fingerCount.Value == 1 ? "On tap" : "On {_fingerCount} finger tap") + 
			(_requiredTapCount.Value == 1 ? "" : " {_requiredTapCount} times") +
			" {_tapEvent}";
	}
}
