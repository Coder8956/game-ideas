
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Moves the rigidbody to position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.MovePosition.html")]
	public sealed class Rigidbody2DMovePosition : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The new position for the Rigidbody object.")]
		[SerializeField]
		private Vector2Var _position;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _position);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.MovePosition(UnityEngine.Vector2);
			_rigidbody2D.Value.MovePosition(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_rigidbody2D} position to {_position}";
		}
	}
}
