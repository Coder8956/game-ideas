
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Returns a point on the perimeter of all enabled Colliders attached to the rigidbo" +
		"dy that is closest to the specified position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.ClosestPoint.html")]
	public sealed class Physics2DClosestPointOnRigidbody : BaseAction
	{
		
		[Tooltip("The position from which to find the closest point on the specified rigidbody.")]
		[SerializeField]
		private Vector2Var _position;
		
		[Tooltip("The Rigidbody on which to find the closest specified position.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_position, _rigidbody, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.ClosestPoint(UnityEngine.Vector2, UnityEngine.Rigidbody2D);
			_result.Value = Physics2D.ClosestPoint(_position.Value, _rigidbody.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Closest Point: {_position} {_rigidbody} -> {_result}";
		}
	}
}
