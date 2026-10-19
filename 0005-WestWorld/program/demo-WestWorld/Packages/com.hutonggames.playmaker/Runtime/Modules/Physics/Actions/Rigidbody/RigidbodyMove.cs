
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("Moves the Rigidbody to position and rotates the Rigidbody to rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.Move.html")]
	public sealed class RigidbodyMove : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The new position for the Rigidbody.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("The new rotation for the Rigidbody.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _position, _rotation);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.Move(UnityEngine.Vector3, UnityEngine.Quaternion);
			_rigidbody.Value.Move(_position.Value, _rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_rigidbody} to {_position} with rotation {_rotation}";
		}
	}
}
