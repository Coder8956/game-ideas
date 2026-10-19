using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Applies gravity to a CharacterController vertical velocity variable. " +
	                   "Optionally writes that vertical velocity into a Move Vector Y component. " +
	                   "Use this before Apply Platform Motion when building a final Move Vector. " +
	                   "<br/>Apply the final Move Vector using CharacterController Move or CharacterController Simple Move.")]
	public sealed class CharacterControllerApplyGravity : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The CharacterController to apply gravity to.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[ActionHeader("Inputs")]

		[Tooltip("Whether the character is grounded. Use one of the CharacterController Check Is Grounded actions.")]
		[SerializeField]
		private BoolRef _isGrounded;

		[Tooltip("Gravity multiplier applied to Physics.gravity.y.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _gravityMultiplier;

		[Tooltip("Small downward velocity used while grounded to keep the CharacterController pressed to the ground.")]
		[SerializeField, DefaultValue(-2f)]
		private FloatVar _groundedVelocity;

		[OptionalField]
		[Tooltip("Optional maximum fall speed. Use a negative value such as -50. Values of 0 or greater are ignored.")]
		[SerializeField]
		private FloatVar _terminalVelocity;

		[ActionHeader("Outputs")]

		[Tooltip("Persistent vertical velocity variable updated by this action.")]
		[SerializeField]
		private FloatRef _verticalVelocity;

		[OptionalField]
		[Tooltip("Optional movement vector to update. The action writes the current vertical velocity to its Y component.")]
		[SerializeField]
		private Vector3Ref _moveVector;

		public override bool CanExecute() =>
			CheckParameters(_characterController, _isGrounded, _verticalVelocity, _gravityMultiplier, _groundedVelocity);

		public override void Execute()
		{
			if (!_characterController.Value)
			{
				return;
			}

			var velocity = _verticalVelocity.Value;

			if (_isGrounded.Value)
			{
				if (velocity <= 0f)
				{
					velocity = _groundedVelocity.Value;
				}
			}
			else
			{
				var gravity = Physics.gravity.y * _gravityMultiplier.Value;
				velocity += gravity * DeltaTime;

				if (!_terminalVelocity.IsNone && _terminalVelocity.Value < 0f)
				{
					velocity = Mathf.Max(velocity, _terminalVelocity.Value);
				}
			}

			_verticalVelocity.Value = velocity;

			if (!_moveVector.IsNone)
			{
				var move = _moveVector.Value;
				move.y = velocity;
				_moveVector.Value = move;
			}
		}

		public override string GetSummary()
		{
			return "Apply gravity to {_characterController} {_moveVector:output} {_verticalVelocity:output}"
			       + (Mathf.Approximately(_gravityMultiplier.Value, 1f) ? string.Empty : " x {_gravityMultiplier}");
		}
	}
}
