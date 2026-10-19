
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("Lerp the kinematic Rigidbody towards a position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html")]
	public sealed class RigidbodyLerpPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The position to move towards.")]
		[SerializeField]
		private Vector3Var _position;

		[Tooltip("The speed of the linear interpolation. " +
		         "Higher values make the rigidbody move faster towards the target position.")]
		[SerializeField, DefaultValue(10f)]
		private FloatVar _lerpSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _position, _lerpSpeed);
		}
		
		public override void Execute()
		{
			var position = Vector3.Lerp(_rigidbody.Value.position, _position.Value, _lerpSpeed.Value * Time.deltaTime);
			_rigidbody.Value.MovePosition(position);
		}
		
		public override string GetSummary()
		{
			return "Lerp {_rigidbody} position to {_position} speed: {_lerpSpeed}";
		}
	}
}
