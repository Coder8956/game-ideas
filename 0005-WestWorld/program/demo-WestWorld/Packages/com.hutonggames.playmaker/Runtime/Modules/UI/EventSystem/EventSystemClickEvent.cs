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
	[ActionDescription("Sends local events when a mouse/touch press clicks UI via EventSystem raycast, and stores click hit data." + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.RaycastAll.html")]
	public sealed class EventSystemClickEvent : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;

		[Tooltip("Which pointer button should trigger this click event.")]
		[SerializeField]
		private EventSystems.PointerButtonFilter _button = EventSystems.PointerButtonFilter.Left;

		[Tooltip("Event to send when the click hits UI.")]
		[SerializeField, OptionalField]
		private EventRef _clickedEvent;

		[Tooltip("Event to send when the click does not hit UI.")]
		[SerializeField, OptionalField]
		private EventRef _noHitEvent;

		[Tooltip("Store the click screen position.")]
		[SerializeField, WriteOnly, OptionalField]
		private Vector2Ref _screenPosition;

		[Tooltip("Store the top UI GameObject clicked.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _clickedGameObject;

		[Tooltip("Store the number of UI hits for this click.")]
		[SerializeField, WriteOnly, OptionalField]
		private IntegerRef _hitCount;

		[Tooltip("Store the top RaycastResult hit.")]
		[SerializeField, WriteOnly, OptionalField]
		private EventSystems.RaycastResultRef _topRaycastResult;

		private readonly List<RaycastResult> _results = new();
		private PointerEventData _pointerEventData;
		private EventSystem _cachedEventSystem;

		public override bool CanExecute() => CheckParameters(_eventSystem);

		public override void Execute()
		{
			if (!IsClickDown())
			{
				return;
			}

			var clickPosition = InputShim.GetMousePosition();
			if (_screenPosition.IsAssigned)
			{
				_screenPosition.Value = clickPosition;
			}

			var eventSystem = _eventSystem.Value;
			if (eventSystem == null)
			{
				StoreNoHit();
				SendEvent(_noHitEvent);
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

			if (_results.Count > 0)
			{
				if (_clickedGameObject.IsAssigned)
				{
					_clickedGameObject.Value = _results[0].gameObject;
				}

				if (_hitCount.IsAssigned)
				{
					_hitCount.Value = _results.Count;
				}

				if (_topRaycastResult.IsAssigned)
				{
					_topRaycastResult.Value = _results[0];
				}

				SendEvent(_clickedEvent);
				return;
			}

			StoreNoHit();
			SendEvent(_noHitEvent);
		}

		private bool IsClickDown()
		{
			switch (_button)
			{
				case EventSystems.PointerButtonFilter.Any:
					return InputShim.GetMouseButtonDown(0) ||
					       InputShim.GetMouseButtonDown(1) ||
					       InputShim.GetMouseButtonDown(2) ||
					       InputShim.AnyTouchDown();

				case EventSystems.PointerButtonFilter.Left:
					return InputShim.GetMouseButtonDown(0) ||
					       InputShim.AnyTouchDown();

				case EventSystems.PointerButtonFilter.Right:
					return InputShim.GetMouseButtonDown(1);

				case EventSystems.PointerButtonFilter.Middle:
					return InputShim.GetMouseButtonDown(2);

				default:
					return false;
			}
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

			if (_topRaycastResult.IsAssigned)
			{
				_topRaycastResult.Value = default;
			}
		}

		public override string GetSummary()
		{
			return "Send {_eventSystem:hide} click event {_clickedEvent} {_noHitEvent} {_clickedGameObject:output}";
		}
	}
}
