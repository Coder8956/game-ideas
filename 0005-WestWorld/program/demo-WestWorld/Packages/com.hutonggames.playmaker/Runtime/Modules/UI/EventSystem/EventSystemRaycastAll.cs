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
	[ActionDescription("Raycast all UI elements at a screen position using an EventSystem.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.RaycastAll.html")]
	public sealed class EventSystemRaycastAll : BaseAction
	{
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;

		[Tooltip("Screen position to raycast at.")]
		[SerializeField]
		private Vector2Var _screenPosition;

		[Tooltip("Store true if the raycast hit one or more UI elements.")]
		[SerializeField, WriteOnly, OptionalField]
		private BoolRef _hasHit;

		[Tooltip("Store the number of UI hits.")]
		[SerializeField, WriteOnly, OptionalField]
		private IntegerRef _hitCount;

		[Tooltip("Store the top UI GameObject hit.")]
		[SerializeField, WriteOnly, OptionalField]
		private GameObjectRef _topGameObject;

		[Tooltip("Store the top RaycastResult hit.")]
		[SerializeField, WriteOnly, OptionalField]
		private EventSystems.RaycastResultRef _topRaycastResult;

		[Tooltip("Store all RaycastResults (top to bottom).")]
		[SerializeField, WriteOnly, OptionalField]
		private EventSystems.RaycastResultListRef _raycastResults;

		private readonly List<RaycastResult> _results = new();
		private PointerEventData _pointerEventData;
		private EventSystem _cachedEventSystem;

		public override bool CanExecute() => CheckParameters(_eventSystem, _screenPosition);

		public override void Execute()
		{
			var eventSystem = _eventSystem.Value;
			if (eventSystem == null)
			{
				StoreResults(0, null, default);
				return;
			}

			if (_pointerEventData == null || _cachedEventSystem != eventSystem)
			{
				_pointerEventData = new PointerEventData(eventSystem);
				_cachedEventSystem = eventSystem;
			}
			_pointerEventData.Reset();
			_pointerEventData.position = _screenPosition.Value;

			_results.Clear();
			eventSystem.RaycastAll(_pointerEventData, _results);

			var hitCount = _results.Count;
			var topGameObject = hitCount > 0 ? _results[0].gameObject : null;
			var topRaycastResult = hitCount > 0 ? _results[0] : default;
			StoreResults(hitCount, topGameObject, topRaycastResult);

			if (_raycastResults.IsAssigned)
			{
				_raycastResults.Value = new List<RaycastResult>(_results);
			}
		}

		private void StoreResults(int hitCount, GameObject topGameObject, RaycastResult topRaycastResult)
		{
			if (_hasHit.IsAssigned)
			{
				_hasHit.Value = hitCount > 0;
			}

			if (_hitCount.IsAssigned)
			{
				_hitCount.Value = hitCount;
			}

			if (_topGameObject.IsAssigned)
			{
				_topGameObject.Value = topGameObject;
			}

			if (_topRaycastResult.IsAssigned)
			{
				_topRaycastResult.Value = topRaycastResult;
			}

			if (_raycastResults.IsAssigned && hitCount == 0)
			{
				_raycastResults.Values = Array.Empty<RaycastResult>();
			}
		}

		public override string GetSummary()
		{
			return "Raycast all from {_eventSystem:hide} {_screenPosition} -> {_topGameObject}";
		}
	}
}
