
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ConvertibleGroup("CharacterControllerMove")]
	[ActionDescription("Apply gravity and call Move on the CharacterController component. " +
	                   "<br/>This is a gravity-only airborne action. If you need to control the CharacterController while in the air, " +
	                   "use CharacterControllerMoveInAir instead. " +
	                   "<br/>This action pairs best with CharacterControllerCheckIsFalling.")]
	public sealed class CharacterControllerFall : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[RequiredComponent(typeof(CharacterController))]
		[Tooltip("The CharacterController to control.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;

		[OptionalField]
		[FormerlySerializedAs("_motion")]
		[Tooltip("Optional initial velocity for the fall state. " +
		         "If set, X/Y/Z seed the in-air velocity when transitioning from jump, glide, or other movement states.")]
		[SerializeField]
		private Vector3Ref _initialVelocity;

		[Tooltip("Interpret the optional initial velocity in local or world space.")]
		[SerializeField]
		private SpaceVar _space;

		[Tooltip("Multiply the physics gravity by this value.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _gravityMultiplier;
		
		[OptionalField]
		[Tooltip("Indicates the direction of a collision: None, Sides, Above, and Below.")]
		[SerializeField]
		[WriteOnly]
		private CollisionFlagsRef _collisionFlags;
		
		[OptionalField]
		[Tooltip("Event to send when landing. Use this to transition back to a grounded State. " +
		         "<br/>Note, this uses the CharacterController isGrounded property which can be flaky. " +
		         "For more control use a CharacterControllerCheckIsGrounded action.")]
		[SerializeField]
		private EventRef _landedEvent;
		
		public override bool CanExecute() => CheckParameters(_characterController, _gravityMultiplier);

		private Vector3 _currentVelocity;

		public override void OnStart()
		{
			base.OnStart();
			var controller = _characterController.Value;
			var velocity = controller.velocity;
			if (!_initialVelocity.IsNone)
			{
				var seededMotion = _initialVelocity.Value;
				if (_space.Value == Space.Self)
				{
					seededMotion = controller.transform.TransformDirection(seededMotion);
				}

				velocity = seededMotion;
			}
			_currentVelocity = velocity;
		}

		
		public override void Execute()
		{
			var controller = _characterController.Value;
			if (!controller)
			{
				return;
			}

			var gravity = Physics.gravity.y * _gravityMultiplier.Value;
			
			// Update our stored velocity with gravity
			_currentVelocity.y += gravity * Time.deltaTime;
        
			// Move using our maintained velocity
			var collisionFlags = controller.Move(_currentVelocity * Time.deltaTime);

			if (_collisionFlags != null && _collisionFlags.IsAssigned)
			{
				_collisionFlags.Value = collisionFlags;
			}

			if (controller.isGrounded && controller.velocity.y < 0.1f)
			{
				controller.Move(Vector3.zero);
                
				SendEvent(_landedEvent);
			}
		}
		

		public override string GetSummary() => 
			"{_characterController} " +
			( _initialVelocity.IsAssigned ? " set {_initialVelocity} then" : "" ) +
			" fall using gravity" 
			+ (Mathf.Approximately(_gravityMultiplier.Value, 1f) ? "" : " x {_gravityMultiplier}")
			+ (_landedEvent.IsSet ? " {_landedEvent}" : "");
	}
}
