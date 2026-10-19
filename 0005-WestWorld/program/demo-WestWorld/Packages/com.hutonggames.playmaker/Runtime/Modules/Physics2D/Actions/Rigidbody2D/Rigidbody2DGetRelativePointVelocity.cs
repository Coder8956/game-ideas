
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The velocity of the rigidbody at the point Point in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetRelativePointVelocity.htm" +
		"l")]
	public sealed class Rigidbody2DGetRelativePointVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The local space point to calculate velocity for.")]
		[SerializeField]
		private Vector2Var _relativePoint;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _relativePoint, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.GetRelativePointVelocity(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetRelativePointVelocity(_relativePoint.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} relative point velocity at {_relativePoint} -> {_result}";
		}
	}
}
