
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Returns a point on the perimeter of the Collider that is closest to the specified" +
		" position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.ClosestPoint.html")]
	public sealed class Physics2DClosestPointOnCollider : BaseAction
	{
		
		[Tooltip("The position from which to find the closest point on the specified Collider.")]
		[SerializeField]
		private Vector2Var _position;
		
		[Tooltip("Collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_position, _collider, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics2D.ClosestPoint(UnityEngine.Vector2, UnityEngine.Collider2D);
			_result.Value = Physics2D.ClosestPoint(_position.Value, _collider.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Closest Point: {_position} {_collider} -> {_result}";
		}
	}
}
