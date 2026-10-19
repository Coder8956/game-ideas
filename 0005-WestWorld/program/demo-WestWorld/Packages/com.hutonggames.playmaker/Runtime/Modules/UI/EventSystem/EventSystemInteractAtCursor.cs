using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[PublicAPI]
	[MovedFrom(true, null, null, "EventSystemCursorInteraction")]
	[ActionCategory(Category.InteractionUI)]
	[ActionDescription("Simulates uGUI hover and button-style pointer interaction at the current cursor position. Also works with CursorLockMode.Locked, where the cursor is treated as the center of the screen. Hover and click are gated by UI raycast distance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.RaycastAll.html")]
	public sealed class EventSystemInteractAtCursor : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;

		[Tooltip("Optional root GameObject. Only interaction targets that are this object or its children will be accepted.")]
		[SerializeField, OptionalField]
		private GameObjectVar _root;

		[Tooltip("Pointer button to use for press and click interaction.")]
		[SerializeField]
		private EventSystems.PointerButtonFilter _button = EventSystems.PointerButtonFilter.Left;

		[Tooltip("Event to send when the pointer is pressed on a valid UI target.")]
		[SerializeField, OptionalField]
		private EventRef _pointerDownEvent;

		[Tooltip("Event to send when the pointer is released after a valid press.")]
		[SerializeField, OptionalField]
		private EventRef _pointerUpEvent;

		[Tooltip("Event to send when press and release complete a click on the same valid UI target.")]
		[SerializeField, OptionalField]
		private EventRef _clickedEvent;

		[Tooltip("Event to send when the pointer is pressed but no valid UI target is hit.")]
		[SerializeField, OptionalField]
		private EventRef _noHitEvent;

		[Tooltip("Maximum UI raycast distance allowed for hover and click. Use 0 or less for no distance limit.")]
		[SerializeField, DefaultValue(0f)]
		private FloatVar _maxDistance;

		[Tooltip("Store true if the cursor raycast is currently over a UI hover target.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _isHovering;

		[Tooltip("Store the current hovered UI GameObject that received pointer enter/exit.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _hoveredGameObject;

		[Tooltip("Store the UI GameObject that received the most recent successful click.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _clickedGameObject;

		private readonly List<RaycastResult> _results = new();
		private PointerEventData _pointerEventData;
		private EventSystem _cachedEventSystem;
		private GameObject _currentHoveredObject;
		private GameObject _pressedObject;
		private GameObject _pressedClickHandler;
		private GameObject _pressedHoveredObject;
		private PointerEventData.InputButton _pressedButton = PointerEventData.InputButton.Left;

		public override bool CanExecute() => CheckParameters(_eventSystem);

		public override void Execute()
		{
			var eventSystem = _eventSystem.Value;
			if (eventSystem == null)
			{
				ClearState();
				StoreResults(null, null);
				return;
			}

			if (_pointerEventData == null || _cachedEventSystem != eventSystem)
			{
				ClearState();
				_pointerEventData = new PointerEventData(eventSystem);
				_cachedEventSystem = eventSystem;
			}

			_pointerEventData.Reset();
			_pointerEventData.position = GetCursorPosition();
			_pointerEventData.delta = Vector2.zero;

			_results.Clear();
			eventSystem.RaycastAll(_pointerEventData, _results);

			var topGameObject = _results.Count > 0 ? _results[0].gameObject : null;
			var topRaycastResult = _results.Count > 0 ? _results[0] : default;
			var hoveredObject = topGameObject != null && IsWithinDistance(topRaycastResult)
				? ResolveHoveredObject(topGameObject)
				: null;
			var hasValidHit = IsUnderRoot(hoveredObject);
			hoveredObject = hasValidHit ? hoveredObject : null;

			_pointerEventData.pointerCurrentRaycast = hasValidHit ? topRaycastResult : default;

			UpdateHover(hoveredObject);
			var clickedObject = HandlePressAndRelease(hasValidHit ? topGameObject : null, hoveredObject);
			StoreResults(hoveredObject, clickedObject);
		}

		public override void OnStop() => ClearState();

		public override void OnStateExit() => ClearState();

		private GameObject HandlePressAndRelease(GameObject topGameObject, GameObject hoveredObject)
		{
			if (_pressedObject == null && TryGetButtonDown(out var button))
			{
				_pressedButton = button;
				_pressedHoveredObject = hoveredObject;
				_pointerEventData.button = button;
				_pointerEventData.pressPosition = _pointerEventData.position;
				_pointerEventData.pointerPressRaycast = _pointerEventData.pointerCurrentRaycast;
				_pointerEventData.pointerPress = null;
				_pointerEventData.rawPointerPress = topGameObject;
				_pointerEventData.eligibleForClick = topGameObject != null;
				_pressedClickHandler = topGameObject != null
					? ExecuteEvents.GetEventHandler<IPointerClickHandler>(topGameObject)
					: null;

				if (topGameObject != null)
				{
					_pressedObject = ExecuteEvents.ExecuteHierarchy(topGameObject, _pointerEventData, ExecuteEvents.pointerDownHandler);
					if (_pressedObject == null)
					{
						_pressedObject = ExecuteEvents.GetEventHandler<IPointerClickHandler>(topGameObject);
					}

					_pointerEventData.pointerPress = _pressedObject;
					if (_pressedObject != null)
					{
						SetSelectedGameObject(_pressedObject);
					}
				}
				else
				{
					_pressedObject = null;
					SendEvent(_noHitEvent);
				}

				if (_pressedObject != null)
				{
					SendEvent(_pointerDownEvent);
				}
			}

			if (_pressedObject != null && TryGetButtonUp(out button) && button == _pressedButton)
			{
				_pointerEventData.button = button;
				ExecuteEvents.Execute(_pressedObject, _pointerEventData, ExecuteEvents.pointerUpHandler);

				var releasedClickHandler = topGameObject != null
					? ExecuteEvents.GetEventHandler<IPointerClickHandler>(topGameObject)
					: null;

				var isSameHoverTarget = _pressedHoveredObject != null && _pressedHoveredObject == hoveredObject;
				var isSameClickHandler = _pressedClickHandler != null && _pressedClickHandler == releasedClickHandler;
				var clickTarget = isSameHoverTarget || isSameClickHandler
					? releasedClickHandler ?? _pressedClickHandler ?? hoveredObject ?? _pressedObject
					: null;

				if (clickTarget != null)
				{
					ExecuteEvents.Execute(clickTarget, _pointerEventData, ExecuteEvents.pointerClickHandler);
				}

				ClearPressedState();
				SendEvent(_pointerUpEvent);

				if (clickTarget != null)
				{
					SendEvent(_clickedEvent);
					return clickTarget;
				}
			}

			return null;
		}

		private void UpdateHover(GameObject hoveredObject)
		{
			if (_currentHoveredObject == hoveredObject)
			{
				if (_pointerEventData != null)
				{
					_pointerEventData.pointerEnter = _currentHoveredObject;
				}

				return;
			}

			if (_currentHoveredObject != null)
			{
				ExecuteEvents.Execute(_currentHoveredObject, _pointerEventData, ExecuteEvents.pointerExitHandler);
			}

			_currentHoveredObject = hoveredObject;
			_pointerEventData.pointerEnter = _currentHoveredObject;

			if (_currentHoveredObject != null)
			{
				ExecuteEvents.Execute(_currentHoveredObject, _pointerEventData, ExecuteEvents.pointerEnterHandler);
			}

		}

		private void ClearState()
		{
			ClearPressedState(sendPointerUp: true);

			if (_currentHoveredObject != null && _pointerEventData != null)
			{
				ExecuteEvents.Execute(_currentHoveredObject, _pointerEventData, ExecuteEvents.pointerExitHandler);
			}

			_currentHoveredObject = null;

			if (_pointerEventData != null)
			{
				_pointerEventData.pointerEnter = null;
				_pointerEventData.pointerCurrentRaycast = default;
			}
		}

		private void ClearPressedState(bool sendPointerUp = false)
		{
			if (sendPointerUp && _pressedObject != null && _pointerEventData != null)
			{
				ExecuteEvents.Execute(_pressedObject, _pointerEventData, ExecuteEvents.pointerUpHandler);
			}

			_pressedObject = null;
			_pressedClickHandler = null;
			_pressedHoveredObject = null;
			_pressedButton = PointerEventData.InputButton.Left;

			if (_pointerEventData != null)
			{
				_pointerEventData.pointerPress = null;
				_pointerEventData.rawPointerPress = null;
				_pointerEventData.eligibleForClick = false;
				_pointerEventData.pointerPressRaycast = default;
			}
		}

		private bool TryGetButtonDown(out PointerEventData.InputButton button)
		{
			switch (_button)
			{
				case EventSystems.PointerButtonFilter.Any:
					if (InputShim.GetMouseButtonDown(0))
					{
						button = PointerEventData.InputButton.Left;
						return true;
					}
					if (InputShim.GetMouseButtonDown(1))
					{
						button = PointerEventData.InputButton.Right;
						return true;
					}
					if (InputShim.GetMouseButtonDown(2))
					{
						button = PointerEventData.InputButton.Middle;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Left:
					if (InputShim.GetMouseButtonDown(0))
					{
						button = PointerEventData.InputButton.Left;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Right:
					if (InputShim.GetMouseButtonDown(1))
					{
						button = PointerEventData.InputButton.Right;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Middle:
					if (InputShim.GetMouseButtonDown(2))
					{
						button = PointerEventData.InputButton.Middle;
						return true;
					}
					break;
			}

			button = PointerEventData.InputButton.Left;
			return false;
		}

		private bool TryGetButtonUp(out PointerEventData.InputButton button)
		{
			switch (_button)
			{
				case EventSystems.PointerButtonFilter.Any:
					if (InputShim.GetMouseButtonUp(0))
					{
						button = PointerEventData.InputButton.Left;
						return true;
					}
					if (InputShim.GetMouseButtonUp(1))
					{
						button = PointerEventData.InputButton.Right;
						return true;
					}
					if (InputShim.GetMouseButtonUp(2))
					{
						button = PointerEventData.InputButton.Middle;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Left:
					if (InputShim.GetMouseButtonUp(0))
					{
						button = PointerEventData.InputButton.Left;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Right:
					if (InputShim.GetMouseButtonUp(1))
					{
						button = PointerEventData.InputButton.Right;
						return true;
					}
					break;

				case EventSystems.PointerButtonFilter.Middle:
					if (InputShim.GetMouseButtonUp(2))
					{
						button = PointerEventData.InputButton.Middle;
						return true;
					}
					break;
			}

			button = PointerEventData.InputButton.Left;
			return false;
		}

		private void SetSelectedGameObject(GameObject target)
		{
			var eventSystem = _cachedEventSystem;
			if (eventSystem == null || target == null)
			{
				return;
			}

			eventSystem.SetSelectedGameObject(target, _pointerEventData);
		}

		private static GameObject ResolveHoveredObject(GameObject topGameObject)
		{
			return topGameObject == null
				? null
				: ExecuteEvents.GetEventHandler<IPointerEnterHandler>(topGameObject);
		}

		private bool IsWithinDistance(RaycastResult raycastResult)
		{
			return _maxDistance.Value <= 0f || raycastResult.distance <= _maxDistance.Value;
		}

		private bool IsUnderRoot(GameObject target)
		{
			if (_root.IsNone || _root.Value == null || target == null)
			{
				return target != null;
			}

			return target.transform.IsChildOf(_root.Value.transform) || target == _root.Value;
		}

		private static Vector2 GetCursorPosition()
		{
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				return new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
			}

			return InputShim.GetMousePosition();
		}

		private void StoreResults(GameObject hoveredObject, GameObject clickedObject)
		{
			if (_isHovering.IsAssigned)
			{
				_isHovering.Value = hoveredObject != null;
			}

			if (_hoveredGameObject.IsAssigned)
			{
				_hoveredGameObject.Value = hoveredObject;
			}

			if (_clickedGameObject.IsAssigned && clickedObject != null)
			{
				_clickedGameObject.Value = clickedObject;
			}
		}

		public override string GetSummary()
		{
			return "Interact at cursor" + 
			       (_root.IsNotDefault() ? " in {_root}" : "") +
			       (_maxDistance.IsNotDefault() ? " distance < {_maxDistance}" : "") +
			       " {_pointerDownEvent} {_pointerUpEvent} {_clickedEvent} {_hoveredGameObject:output} {_clickedGameObject:output}";
		}
	}
}
