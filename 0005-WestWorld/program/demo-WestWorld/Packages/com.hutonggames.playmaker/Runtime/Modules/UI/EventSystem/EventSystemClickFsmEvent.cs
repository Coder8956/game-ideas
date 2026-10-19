using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Sends global events to an FSM on the clicked UI GameObject, with optional per-button events." + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.RaycastAll.html")]
	public sealed class EventSystemClickFsmEvent : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("Store the top UI GameObject clicked.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _clickedGameObject;
		
		[OptionalField]
		[Tooltip("The name of the FSM to target. If empty, uses the first FSM component found.")]
		[SerializeField]
		private StringVar _fsmName;
		
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[GlobalEvent]
		[Tooltip("Global event sent to the clicked GameObject FSM for left mouse button (and touch).")]
		[SerializeField, OptionalField]
		private EventRef _leftButtonEvent;

		[GlobalEvent]
		[Tooltip("Global event sent to the clicked GameObject FSM for right mouse button.")]
		[SerializeField, OptionalField]
		private EventRef _rightButtonEvent;
		
		[GlobalEvent]
		[Tooltip("Global event sent to the clicked GameObject FSM for middle mouse button.")]
		[SerializeField, OptionalField]
		private EventRef _middleButtonEvent;
		
		[GlobalEvent]
		[Tooltip("Global event sent when no UI element is hit.")]
		[SerializeField, OptionalField]
		private EventRef _noHitEvent;

		[GlobalEvent]
		[Tooltip("Global event sent to the clicked GameObject FSM for any mouse button (and touch).")]
		[SerializeField, OptionalField]
		private EventRef _anyButtonEvent;
		
		[Tooltip("Store the number of UI hits for this click.")]
		[SerializeField, WriteOnly, OptionalField]
		private IntegerRef _hitCount;

		private readonly List<RaycastResult> _results = new();
		private PointerEventData _pointerEventData;
		private EventSystem _cachedEventSystem;

		public override bool CanExecute() => CheckParameters(_eventSystem);

		public override string ErrorCheck()
		{
			if (!HasAnyTargetEvent())
			{
				return "Assign at least one global event.";
			}

			if (IsInvalidGlobalEvent(_anyButtonEvent) ||
			    IsInvalidGlobalEvent(_leftButtonEvent) ||
			    IsInvalidGlobalEvent(_middleButtonEvent) ||
			    IsInvalidGlobalEvent(_rightButtonEvent) ||
			    IsInvalidGlobalEvent(_noHitEvent))
			{
				return "All assigned events must be Global Events!";
			}

			return null;
		}

		public override void Execute()
		{
			if (!TryGetPressedButton(out var pressedButton))
			{
				return;
			}

			var clickPosition = InputShim.GetMousePosition();
			var eventSystem = _eventSystem.Value;
			if (eventSystem == null)
			{
				StoreNoHit();
				return;
			}

			if (_pointerEventData == null || _cachedEventSystem != eventSystem)
			{
				_pointerEventData = new PointerEventData(eventSystem);
				_cachedEventSystem = eventSystem;
			}
			_pointerEventData.Reset();
			_pointerEventData.position = clickPosition;

			_results.Clear();
			eventSystem.RaycastAll(_pointerEventData, _results);

			if (_results.Count == 0)
			{
				StoreNoHit();
				return;
			}

			var clickedGameObject = _results[0].gameObject;
			if (_clickedGameObject.IsAssigned)
			{
				_clickedGameObject.Value = clickedGameObject;
			}

			if (_hitCount.IsAssigned)
			{
				_hitCount.Value = _results.Count;
			}

			SendGlobalEvent(_anyButtonEvent, clickedGameObject);

			switch (pressedButton)
			{
				case EventSystems.PointerButtonFilter.Left:
					SendGlobalEvent(_leftButtonEvent, clickedGameObject);
					break;
				case EventSystems.PointerButtonFilter.Middle:
					SendGlobalEvent(_middleButtonEvent, clickedGameObject);
					break;
				case EventSystems.PointerButtonFilter.Right:
					SendGlobalEvent(_rightButtonEvent, clickedGameObject);
					break;
			}
		}

		private bool TryGetPressedButton(out EventSystems.PointerButtonFilter pressedButton)
		{
			if (InputShim.GetMouseButtonDown(0) || InputShim.AnyTouchDown())
			{
				pressedButton = EventSystems.PointerButtonFilter.Left;
				return true;
			}

			if (InputShim.GetMouseButtonDown(1))
			{
				pressedButton = EventSystems.PointerButtonFilter.Right;
				return true;
			}

			if (InputShim.GetMouseButtonDown(2))
			{
				pressedButton = EventSystems.PointerButtonFilter.Middle;
				return true;
			}

			pressedButton = EventSystems.PointerButtonFilter.Any;
			return false;
		}

		private void StoreNoHit()
		{
			if (_clickedGameObject.IsAssigned)
			{
				_clickedGameObject.Value = null;
			}

			if (_hitCount.IsAssigned)
			{
				_hitCount.Value = 0;
			}

			SendGlobalEvent(_noHitEvent, OwnerGameObject);
		}

		private bool HasAnyTargetEvent()
		{
			return _anyButtonEvent.IsSet ||
			       _leftButtonEvent.IsSet ||
			       _middleButtonEvent.IsSet ||
			       _rightButtonEvent.IsSet ||
			       _noHitEvent.IsSet;
		}

		private static bool IsInvalidGlobalEvent(EventRef evt)
		{
			return evt.IsSet && !evt.IsGlobalEvent;
		}

		private void SendGlobalEvent(EventRef eventRef, GameObject target)
		{
			if (!eventRef.IsSet || target == null)
			{
				return;
			}

			var runtimeEvent = eventRef.GetRuntimeEvent(new EventSender(this));
			((GlobalEvent)eventRef.Event).SendToGameObjectFsm(runtimeEvent, target, _fsmName.Value);
		}

		public override string GetSummary()
		{
			var summary = "Send click event to GameObject FSM";
			if (_fsmName.IsNotDefault())
			{
				summary += " {_fsmName}";
			}

			summary += " -> {_clickedGameObject}";
			return summary;
		}
	}
}
