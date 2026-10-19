
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ConvertibleGroup("CharacterControllerMove")]
	[ActionDescription("Calls SimpleMove on the CharacterController. Velocity along the y-axis is ignored. " +
	                   "Speed is in units/s. Gravity is automatically applied. Returns if the character is grounded. " +
	                   "It is recommended that you make only one call to Move or SimpleMove per frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.SimpleMove.html")]
	public sealed class CharacterControllerSimpleMove : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The CharacterController.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Movement in units/s.")]
		[SerializeField, DefaultValue(DefaultValueAttribute.None)]
		private Vector3Var _motion;
		
		[Tooltip("Scale the motion by this value.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		[Tooltip("Move in local space instead of world space.")]
		[SerializeField]
		private BoolVar _localSpace;
		
		[ActionHeader("Ground Detection")]
		
		[OptionalField, WriteOnly]
		[Tooltip("Is the character grounded.")]
		[SerializeField]
		private BoolRef _isGrounded;

		[OptionalField]
		[Tooltip("Event to send when character starts falling. " +
		         "This uses Is Grounded and a small Raycast to check " +
		         "that we're not just going down a slope or steps.")]
		[SerializeField]
		private EventRef _fallingEvent;
		
		[OptionalField]
		[Tooltip("Event to send when character lands. " +
		         "This uses Is Grounded and a small Raycast to check " +
		         "that we're not just going down a slope or steps.")]
		[SerializeField]
		private EventRef _landingEvent;
		
		public override bool CanExecute() => CheckParameters(_characterController, _motion, _multiplier);

		public override void Execute()
		{
			var controller = _characterController.Value;
			if (!controller) return;
			
			var move = _motion.Value * _multiplier.Value;
			if (_localSpace.Value)
			{
				move = controller.transform.TransformDirection(move);
			}
			
			controller.SimpleMove(move);
			
			// Skip ground checks if not needed
			if (!_isGrounded.IsAssigned && !_fallingEvent.IsSet) 
				return;
			
			var isReallyGrounded = CheckGrounded(controller);
			_isGrounded.Value = isReallyGrounded;

			SendEvent(!isReallyGrounded ? _fallingEvent : _landingEvent);
		}
		
		/// <summary>
		/// controller.isGrounded is unreliable. E.g., it can return false when not moving.
		/// It also doesn't work well when walking down slopes or stairs
		/// https://forum.unity.com/threads/charactercontroller-and-walking-down-a-stairs.101859/
		/// So we double-check if we're really grounded using a raycast down.
		/// We use the controller stepOffset as the ray distance. 
		/// If the ray hits something, we assume we're just stepping down and not really falling.
		/// </summary>
		private bool CheckGrounded(CharacterController controller)
		{
			// Calculate the bottom center of the capsule, accounting for skin width
			var bottomPosition = controller.transform.position +
			                     Vector3.down * (controller.height / 2);

			return controller.isGrounded ||
			       Physics.Raycast(bottomPosition, Vector3.down, controller.stepOffset + controller.skinWidth);
		}


		public override string GetSummary() => 
			"Move {_characterController} by {_motion}" 
			+ (Mathf.Approximately(_multiplier.Value, 1) ? "" : " x {_multiplier}")
			+ " {_isGrounded:output}";
	}
}
