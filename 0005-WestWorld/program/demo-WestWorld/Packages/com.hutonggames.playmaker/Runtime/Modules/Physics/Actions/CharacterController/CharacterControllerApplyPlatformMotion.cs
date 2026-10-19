using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Gets the motion of the platform a CharacterController is standing on. " +
	                   "<br/>Platform Velocity is returned in units per second for CharacterController.SimpleMove. " +
	                   "<br/>Platform Delta returns the absolute movement delta for this frame for CharacterController.Move. " +
	                   "<br/>If Move Vector is assigned, platform X/Z are added and platform Y is applied while on a platform. " +
	                   "<br/>Use this after Apply Gravity when building a final Move Vector. " +
	                   "<br/>Apply the final Move Vector using CharacterController Move or CharacterController Simple Move.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.html")]
	public sealed class CharacterControllerApplyPlatformMotion : BaseAction
	{
		private const float MinDeltaTime = 0.0001f;
		private const float GroundCastPadding = 0.05f;
		private int PlatformLayerMask => _platformLayers?.Value ?? Physics.DefaultRaycastLayers;
		private bool UseLocalSpace => _localSpace != null && _localSpace.Value;

		[Tooltip("The CharacterController to inspect.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;

		[ActionHeader("Inputs")]
		
		[Tooltip("Layers considered valid platforms. Defaults to Physics.DefaultRaycastLayers.")]
		[SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
		private LayerMaskVar _platformLayers;
		
		[Tooltip("Return platform velocity and delta in CharacterController local space instead of world space.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _localSpace;

		[ActionHeader("Outputs")]

		[OptionalField]
		[Tooltip("Optional movement vector to update. Platform X/Z are added, and Y is overwritten while on a platform.")]
		[SerializeField]
		private Vector3Ref _moveVector;
			
		[OptionalField]
		[Tooltip("Platform velocity in units per second.<br/>Add this to CharacterController SimpleMove, or to CharacterController Move when Per Second is enabled.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _platformVelocity;

		[OptionalField]
		[Tooltip("Platform movement delta for this frame.<br/>Add this to CharacterController Move only when Per Second is disabled.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _platformDelta;

		[OptionalField]
		[Tooltip("The platform currently being tracked.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _platform;

		[OptionalField]
		[Tooltip("True if the CharacterController is currently standing on a detected platform.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _isOnPlatform;

		private readonly RaycastHit[] _groundHits = new RaycastHit[8];
		private Transform _trackedPlatform;
		private Vector3 _lastPlatformPosition;
		private bool _hasTrackedPosition;

		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		public override bool CanExecute() => CheckParameters(_characterController, _platformLayers, _localSpace);

		public override void OnStateEnter()
		{
			ResetTracking();
			ClearOutputs();
		}

		public override void OnStateExit()
		{
			ResetTracking();
		}

		public override void Execute()
		{
			var controller = _characterController.Value;
			if (!controller)
			{
				ResetTracking();
				ClearOutputs();
				return;
			}

			var currentPlatform = GetCurrentPlatform(controller);
			AssignPlatformOutputs(currentPlatform);

			if (!currentPlatform)
			{
				ResetTracking();
				ClearMotionOutputs();
				return;
			}

			var currentPosition = currentPlatform.position;
			if (currentPlatform != _trackedPlatform || !_hasTrackedPosition)
			{
				_trackedPlatform = currentPlatform;
				_lastPlatformPosition = currentPosition;
				_hasTrackedPosition = true;
				ClearMotionOutputs();
				ApplyMotionToMoveVector(Vector3.zero);
				return;
			}

			var delta = currentPosition - _lastPlatformPosition;
			_lastPlatformPosition = currentPosition;

			var motion = Time.deltaTime >= MinDeltaTime
				? delta / Time.deltaTime
				: Vector3.zero;

			if (UseLocalSpace)
			{
				motion = controller.transform.InverseTransformDirection(motion);
				delta = controller.transform.InverseTransformDirection(delta);
			}

			if (_platformVelocity != null && _platformVelocity.IsAssigned)
			{
				_platformVelocity.Value = motion;
			}

			if (_platformDelta != null && _platformDelta.IsAssigned)
			{
				_platformDelta.Value = delta;
			}

			ApplyMotionToMoveVector(motion);
		}

		public override string GetSummary()
		{
			return "Apply platform velocity to {_characterController} {_moveVector:output} {_platformVelocity:output}";
		}

		private Transform GetCurrentPlatform(CharacterController controller)
		{
			var transformCache = controller.transform;
			var bounds = controller.bounds;
			var origin = bounds.center + Vector3.up * GroundCastPadding;
			var distance = Mathf.Max(bounds.extents.y + controller.stepOffset + controller.skinWidth + GroundCastPadding,
			                         GroundCastPadding * 2f);

			var hitCount = Physics.RaycastNonAlloc(origin,
			                                       Vector3.down,
			                                       _groundHits,
			                                       distance,
			                                       PlatformLayerMask,
			                                       QueryTriggerInteraction.Ignore);

			Transform closestPlatform = null;
			var closestDistance = float.MaxValue;

			for (var i = 0; i < hitCount; ++i)
			{
				var hit = _groundHits[i];
				var collider = hit.collider;
				if (!collider)
				{
					continue;
				}

				var hitTransform = collider.transform;
				if (hitTransform == transformCache || hitTransform.IsChildOf(transformCache))
				{
					continue;
				}

				if (hit.distance >= closestDistance)
				{
					continue;
				}

				closestDistance = hit.distance;
				closestPlatform = hit.rigidbody ? hit.rigidbody.transform : hitTransform;
			}

			return closestPlatform;
		}

		private void AssignPlatformOutputs(Transform platform)
		{
			if (_platform != null && _platform.IsAssigned)
			{
				_platform.Value = platform ? platform.gameObject : null;
			}

			if (_isOnPlatform != null && _isOnPlatform.IsAssigned)
			{
				_isOnPlatform.Value = platform != null;
			}
		}

		private void ClearOutputs()
		{
			ClearMotionOutputs();
			AssignPlatformOutputs(null);
		}

		private void ClearMotionOutputs()
		{
			if (_platformVelocity != null && _platformVelocity.IsAssigned)
			{
				_platformVelocity.Value = Vector3.zero;
			}

			if (_platformDelta != null && _platformDelta.IsAssigned)
			{
				_platformDelta.Value = Vector3.zero;
			}
		}

		private void ApplyMotionToMoveVector(Vector3 motion)
		{
			if (_moveVector == null || _moveVector.IsNone)
			{
				return;
			}

			var move = _moveVector.Value;
			move.x += motion.x;
			move.y = motion.y;
			move.z += motion.z;
			_moveVector.Value = move;
		}

		private void ResetTracking()
		{
			_trackedPlatform = null;
			_lastPlatformPosition = Vector3.zero;
			_hasTrackedPosition = false;
		}
	}
}
