
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Returns a point on the perimeter of all enabled Colliders attached to this Rigidb" +
		"ody that is closest to the specified position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.ClosestPoint.html")]
	public sealed class Rigidbody2DClosestPoint : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The position from which to find the closest point on this Rigidbody.")]
		[SerializeField]
		private Vector2Var _position;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _position, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.ClosestPoint(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.ClosestPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest point on {_rigidbody2D} to {_position} -> {_result}";
		}
	}
}
