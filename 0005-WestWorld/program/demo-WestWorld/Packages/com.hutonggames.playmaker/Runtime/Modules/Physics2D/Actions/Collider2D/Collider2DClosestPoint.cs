
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Returns a point on the perimeter of this Collider that is closest to the specifie" +
		"d position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.ClosestPoint.html")]
	public sealed class Collider2DClosestPoint : BaseAction
	{
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("The position from which to find the closest point on this Collider.")]
		[SerializeField]
		private Vector2Var _position;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _position, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.ClosestPoint(UnityEngine.Vector2);
			_result.Value = _collider2D.Value.ClosestPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest point on {_collider2D} to {_position} -> {_result}";
		}
	}
}
