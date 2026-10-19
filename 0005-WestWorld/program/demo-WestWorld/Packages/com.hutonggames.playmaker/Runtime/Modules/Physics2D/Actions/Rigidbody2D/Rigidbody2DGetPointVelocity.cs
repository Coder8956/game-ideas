
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The velocity of the rigidbody at the point Point in global space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetPointVelocity.html")]
	public sealed class Rigidbody2DGetPointVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The global space point to calculate velocity for.")]
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
			//UnityEngine.Rigidbody2D.GetPointVelocity(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetPointVelocity(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} point velocity at {_point} -> {_result}";
		}
	}
}
