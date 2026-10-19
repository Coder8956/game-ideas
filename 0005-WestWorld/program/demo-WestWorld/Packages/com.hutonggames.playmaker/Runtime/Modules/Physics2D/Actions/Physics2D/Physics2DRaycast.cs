
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a ray against Colliders in the Scene, returning the first Collider that contacts with it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html")]
	public sealed class Physics2DRaycast : BaseAction
	{
		
		[Tooltip("The point in 2D space where the ray originates.")]
		[SerializeField]
		private Vector2Var _origin;
		
		[Tooltip("A vector representing the direction of the ray.")]
		[SerializeField]
		private Vector2Var _direction;
		
		[Tooltip("The maximum distance over which to cast the ray.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[ActionHeader("Filter")]
		
		[Tooltip("Filter to check objects only on specific layers.")]
		[SerializeField]
		[DefaultValue("~Physics2DDefaultRaycastLayers")]
		private LayerMaskVar _layerMask;

		[Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatNegativeInfinity")]
		private FloatVar _minDepth;
		
		[Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatPositiveInfinity")]
		private FloatVar _maxDepth;
		
		[ActionHeader("Result")]

		[OptionalField]
		[Tooltip("Event to send if the ray hits something.")]
		[SerializeField]
		private EventRef _hitEvent;

		[OptionalField]
		[Tooltip("Event to send if the ray doesn't hit something.")]
		[SerializeField]
		private EventRef _notHitEvent;

		[OptionalField]
		[DisplayName("DidHit")]
		[WriteOnly]
		[Tooltip("Store whether the raycast hit something.")]
		[SerializeField]
		private BoolRef _didHit;
		
		[WriteOnly]
		[Tooltip("The GameObject hit by the raycast.")]
		[SerializeField, OptionalField]
		private GameObjectRef _gameObjectHit;
		
		[WriteOnly]
		[Tooltip("Store the results in RaycastHit2D variable.")]
		[SerializeField, OptionalField]
		private RaycastHit2DRef _result;
		
		public override bool CanExecute() => 
			CheckParameters(_origin, _direction, _maxDistance, _layerMask, _minDepth, _maxDepth);

		public override string ErrorCheck()
		{
			return HasOutputs
				? string.Empty
				: "Specify at least one output or event.";
		}

		public override void Execute()
		{
			var result = Physics2D.Raycast(
				_origin.Value, _direction.Value, _maxDistance.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
			var didHit = result.collider != null;

			if (_didHit.IsAssigned)
			{
				_didHit.Value = didHit;
			}

			if (_result.IsAssigned)
			{
				_result.Value = result;
			}

			if (_gameObjectHit.IsAssigned)
			{
				_gameObjectHit.Value = result.collider ? result.collider.gameObject : null;
			}

			SendEvent(didHit ? _hitEvent : _notHitEvent);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Raycast from {_origin} direction {_direction} " +
			       (_hitEvent.IsSet ? "Hit {_hitEvent} " : "") +
			       (_notHitEvent.IsSet ? "Not Hit {_notHitEvent} " : "") +
			       "-> {_result} {_gameObjectHit:output} {_didHit:output}";
		}

		private bool HasOutputs => _hitEvent.IsSet || _notHitEvent.IsSet || _didHit.IsAssigned || _result.IsAssigned || _gameObjectHit.IsAssigned;
	}
}
