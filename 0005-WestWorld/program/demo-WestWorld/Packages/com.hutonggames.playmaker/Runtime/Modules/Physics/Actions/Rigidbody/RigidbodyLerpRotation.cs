
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("Lerp the kinematic Rigidbody towards a rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html")]
	public sealed class RigidbodyLerpRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The rotation to lerp towards.")]
		[SerializeField]
		private QuaternionVar _rotation;

		[Tooltip("The speed of the linear interpolation. " +
		         "Higher values make the rigidbody move faster towards the target position.")]
		[SerializeField, DefaultValue(10f)]
		private FloatVar _lerpSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _rotation, _lerpSpeed);
		}
		
		public override void Execute()
		{
			var rotation = Quaternion.Slerp(_rigidbody.Value.rotation, _rotation.Value, _lerpSpeed.Value * Time.deltaTime);
			_rigidbody.Value.MoveRotation(rotation);
		}
		
		public override string GetSummary()
		{
			return "Lerp {_rigidbody} rotation to {_rotation} speed: {_lerpSpeed}";
		}
	}
}
