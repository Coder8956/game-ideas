
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI, Serializable]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Sends an event when a swipe is detected.")]
	public sealed class InputSwipeEvent : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		[Tooltip("Number of fingers needed to detect swipe. 1 = single finger, 2 = two fingers, etc.")]
		[SerializeField, DefaultValue(1)]
		private IntegerVar _fingerCount;
		
		[Tooltip("How far a touch has to travel to be considered a swipe. Uses normalized distance (e.g. 1 = 1 screen diagonal distance). Should generally be a very small number.")]
		[SerializeField, DefaultValue(0.1f)]
		private FloatVar _minSwipeDistance;
		
		[OptionalField]
		[Tooltip("Event to send when swipe left detected.")]
		[SerializeField]
		private EventRef _swipeLeftEvent;
		
		[OptionalField]
		[Tooltip("Event to send when swipe right detected.")]
		[SerializeField]
		private EventRef _swipeRightEvent;
		
		[OptionalField]
		[Tooltip("Event to send when swipe up detected.")]
		[SerializeField]
		private EventRef _swipeUpEvent;
		
		[OptionalField]
		[Tooltip("Event to send when swipe down detected.")]
		[SerializeField]
		private EventRef _swipeDownEvent;

		private float _screenDiagonalSize;
		private float _minSwipeDistancePixels;
		private bool _touchStarted;
		private Vector2 _touchStartPos;
		private int _highestTouchCount;
		
		public override bool CanExecute() => CheckParameters(_fingerCount, _minSwipeDistance);

		public override void OnStart()
		{
			_screenDiagonalSize = Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
			_minSwipeDistancePixels = _minSwipeDistance.Value * _screenDiagonalSize;
		}

		public override void Execute()
		{
			if (Input.touchCount <= 0)
			{
				_touchStarted = false;
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
			switch (touch.phase) 
			{
				case TouchPhase.Began:
					
					_touchStarted = true;
					_touchStartPos = touch.position;
					//touchStartTime = FsmTime.RealtimeSinceStartup;
					break;
					
				case TouchPhase.Ended:
					if (_touchStarted && _highestTouchCount >= _fingerCount.Value)
					{
						TestForSwipeGesture(touch.position);
						_touchStarted = false;
					}
					break;
					
				case TouchPhase.Canceled:
					_touchStarted = false;
					break;
					
				case TouchPhase.Stationary:
					
/*					if (touchStarted)
					{
						// don't want idle time to count towards swipe

						touchStartPos = touch.position;
						touchStartTime = FsmTime.RealtimeSinceStartup;
					}*/
					
					break;

				case TouchPhase.Moved:
					break;
			}
		}
		
		private void TestForSwipeGesture(Vector2 touchPosition)
		{
			var distance = Vector2.Distance(touchPosition, _touchStartPos);
			if (!(distance > _minSwipeDistancePixels)) return;
			
			var dy = touchPosition.y - _touchStartPos.y;
			var dx = touchPosition.x - _touchStartPos.x;
			var angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);
			angle = (360 + angle - 45) % 360;
				
			if (angle < 90)
			{
				SendEvent(_swipeRightEvent);
			}
			else if (angle < 180)
			{
				SendEvent(_swipeDownEvent);
			}
			else if (angle < 270)
			{
				SendEvent(_swipeLeftEvent);
			}
			else 
			{
				SendEvent(_swipeUpEvent);
			}
		}

		public override string GetSummary() => 
			(_fingerCount.Value == 1 ? "On swipe" : "On {_fingerCount} finger swipe" ) +
			(_swipeLeftEvent.IsSet ? " Left {_swipeLeftEvent}" : "") +
			(_swipeRightEvent.IsSet ? " Right {_swipeRightEvent}" : "") +
			(_swipeUpEvent.IsSet ? " Up {_swipeUpEvent}" : "") +
			(_swipeDownEvent.IsSet ? " Down {_swipeDownEvent}" : "");
	}
}
