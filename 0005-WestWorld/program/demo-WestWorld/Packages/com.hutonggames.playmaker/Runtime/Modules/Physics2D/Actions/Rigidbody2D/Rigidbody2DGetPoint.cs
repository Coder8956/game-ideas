
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get a local space point given a point in rigidBody global space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetPoint.html")]
	public sealed class Rigidbody2DGetPoint : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The global space point to transform into local space.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.GetPoint(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetPoint(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} point {_point} -> {_result}";
		}
	}
}
