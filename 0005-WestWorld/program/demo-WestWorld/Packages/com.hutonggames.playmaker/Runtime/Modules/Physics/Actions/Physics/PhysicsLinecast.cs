
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Performs a linecast between start and end. Optionally stores whether anything was hit and information about the hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Linecast.html")]
	public sealed class PhysicsLinecast : BaseAction
	{
		
		[Tooltip("Start point.")]
		[SerializeField]
		private Vector3Var _start;
		
		[Tooltip("End point.")]
		[SerializeField]
		private Vector3Var _end;
		
		[Tooltip("A Layer mask that is used to selectively ignore colliders when casting a ray.")]
		[SerializeField]
		[DefaultValue("Physics.DefaultRaycastLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Specifies whether this query should hit Triggers.")]
		[DefaultValue(QueryTriggerInteraction.UseGlobal)]
		[SerializeField]
		private QueryTriggerInteraction _hitTriggers;

		[ActionHeader("Result")]

		[OptionalField]
		[Tooltip("Event to send if the line hits something.")]
		[SerializeField]
		private EventRef _hitEvent;

		[OptionalField]
		[Tooltip("Event to send if the line doesn't hit something.")]
		[SerializeField]
		private EventRef _notHitEvent;
		
		[DisplayName("DidHit")]
		[Tooltip("Store whether the linecast hit something.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private BoolRef _result;

		[Tooltip("The GameObject hit by the linecast.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private GameObjectRef _gameObjectHit;

		[Tooltip("Store hit information from the linecast.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private RaycastHitRef _hitInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _layerMask);
		}

		public override string ErrorCheck()
		{
			return HasOutputs
				? string.Empty
				: "Specify at least one output or event.";
		}
		
		public override void Execute()
		{
			var didHit = Physics.Linecast(_start.Value, _end.Value, out var hitInfo, _layerMask.Value, _hitTriggers);
			
			if (_result.HasValue())
			{
				_result.Value = didHit;
			}
			
			if (_hitInfo.HasValue())
			{
				_hitInfo.Value = hitInfo;
			}

			if (_gameObjectHit.IsAssigned)
			{
				_gameObjectHit.Value = hitInfo.collider ? hitInfo.collider.gameObject : null;
			}

			SendEvent(didHit ? _hitEvent : _notHitEvent);
		}
		
		public override string GetSummary()
		{
			return "Physics Linecast from {_start} to {_end} " +
			       (_hitEvent.IsSet ? "Hit {_hitEvent} " : "") +
			       (_notHitEvent.IsSet ? "Not Hit {_notHitEvent} " : "") +
			       "using {_layerMask} {_hitInfo:output} {_gameObjectHit:output} {_result:output}";
		}

		private bool HasOutputs => _hitEvent.IsSet || _notHitEvent.IsSet || _result.HasValue() || _gameObjectHit.IsAssigned || _hitInfo.HasValue();
	}
}
