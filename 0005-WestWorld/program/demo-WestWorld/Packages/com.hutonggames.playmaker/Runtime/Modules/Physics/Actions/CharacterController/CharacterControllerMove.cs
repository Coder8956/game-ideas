
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ConvertibleGroup("CharacterControllerMove")]
	[ActionDescription("Calls Move on a GameObject with an attached CharacterController component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController.Move.html")]
	public sealed class CharacterControllerMove : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The CharacterController to move.")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Moves the GameObject in the given direction. " +
		         "The given direction requires absolute movement delta values. " +
		         "A collision constrains the Move from taking place." + Strings.PerSecondNote)]
		[SerializeField]
		private Vector3Var _motion;

		[Tooltip("Scale the motion by this value.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		[Tooltip("Move in local space instead of world space.")]
		[SerializeField]
		private BoolVar _localSpace;
		
		[OptionalField]
		[Tooltip("Indicates the direction of a collision: None, Sides, Above, and Below.")]
		[SerializeField]
		[WriteOnly]
		private CollisionFlagsRef _collisionFlags;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_characterController, _motion, _multiplier);

		public override void Execute()
		{
			var move = _motion.Value * (_multiplier.Value * PerSecond);
			if (_localSpace.Value)
			{
				move = _characterController.Value.transform.TransformDirection(move);
			}
			_collisionFlags.Value = _characterController.Value.Move(move);
		}

		public override string GetSummary() => 
			"Move {_characterController} by {_motion}"
			+ (Mathf.Approximately(_multiplier.Value, 1) ? "" : " x {_multiplier}")
			+ " {PerSecond} {_collisionFlags:output}";
	}
}
