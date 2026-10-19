
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Check if any of the Rigidbody2D colliders overlap a point in space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.OverlapPoint.html")]
	public sealed class Rigidbody2DOverlapPoint : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("A point in world space.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.OverlapPoint(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.OverlapPoint(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_rigidbody2D} overlap point {_point} -> {_result}";
		}
	}
}
