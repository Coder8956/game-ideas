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
	[ActionDescription("Simulates uGUI pointer hover at the current cursor position and sends pointer enter/exit events. Also works with CursorLockMode.Locked, where the cursor is treated as the center of the screen.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.RaycastAll.html")]
	public sealed class EventSystemCursorHover : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;

		[Tooltip("Optional root GameObject. Only hover targets that are this object or its children will be accepted.")]
		[SerializeField, OptionalField]
		private GameObjectVar _root;

		[Tooltip("Maximum UI raycast distance allowed for hover. Use 0 or less for no distance limit.")]
		[SerializeField, DefaultValue(0f)]
		private FloatVar _maxDistance;

		[Tooltip("Store true if the cursor raycast is currently over a UI hover target.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _isHovering;

		[Tooltip("Store the current hovered UI GameObject that received pointer enter/exit.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _hoveredGameObject;

		private readonly List<RaycastResult> _results = new();
		private PointerEventData _pointerEventData;
		private EventSystem _cachedEventSystem;
		private GameObject _currentHoveredObject;

		public override bool CanExecute() => CheckParameters(_eventSystem);

		public override void Execute()
		{
			var eventSystem = _eventSystem.Value;
			if (eventSystem == null)
			{
				ClearHover();
				StoreResults(null);
				return;
			}

			if (_pointerEventData == null || _cachedEventSystem != eventSystem)
			{
				ClearHover();
				_pointerEventData = new PointerEventData(eventSystem);
				_cachedEventSystem = eventSystem;
			}

			_pointerEventData.Reset();
			_pointerEventData.position = GetCursorPosition();
			_pointerEventData.delta = Vector2.zero;
			_pointerEventData.button = PointerEventData.InputButton.Left;

			_results.Clear();
			eventSystem.RaycastAll(_pointerEventData, _results);

			var topGameObject = _results.Count > 0 ? _results[0].gameObject : null;
			var topRaycastResult = _results.Count > 0 ? _results[0] : default;
			var hoveredObject = IsWithinDistance(topRaycastResult)
				? ResolveHoveredObject(topGameObject)
				: null;
			hoveredObject = IsUnderRoot(hoveredObject) ? hoveredObject : null;

			_pointerEventData.pointerCurrentRaycast = topRaycastResult;

			UpdateHover(hoveredObject);
			StoreResults(hoveredObject);
		}

		public override void OnStop() => ClearHover();

		public override void OnStateExit() => ClearHover();

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

		private void ClearHover()
		{
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

		private void StoreResults(GameObject hoveredObject)
		{
			if (_isHovering.IsAssigned)
			{
				_isHovering.Value = hoveredObject != null;
			}

			if (_hoveredGameObject.IsAssigned)
			{
				_hoveredGameObject.Value = hoveredObject;
			}
		}

		public override string GetSummary()
		{
			return "Cursor hover {_root} max {_maxDistance} -> {_hoveredGameObject:output}";
		}
	}
}
