
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("Rotates the rigidbody to rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html")]
	public sealed class RigidbodyMoveRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The new rotation for the Rigidbody.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _rotation);

		public override void Execute() => _rigidbody.Value.MoveRotation(_rotation.Value);

		public override string GetSummary() => "Move {_rigidbody} rotation to {_rotation}";
	}
}
