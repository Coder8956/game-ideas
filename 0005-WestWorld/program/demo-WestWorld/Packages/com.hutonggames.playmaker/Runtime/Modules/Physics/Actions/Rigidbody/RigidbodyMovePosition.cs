
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("Moves the kinematic Rigidbody towards position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html")]
	public sealed class RigidbodyMovePosition : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Provides the new position for the Rigidbody object.")]
		[SerializeField]
		private Vector3Var _position;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _position);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.MovePosition(UnityEngine.Vector3);
			_rigidbody.Value.MovePosition(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_rigidbody} position to {_position}";
		}
	}
}
