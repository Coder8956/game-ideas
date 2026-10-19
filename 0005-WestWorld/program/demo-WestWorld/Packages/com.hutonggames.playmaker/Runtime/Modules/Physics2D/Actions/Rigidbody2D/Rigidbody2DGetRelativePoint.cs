
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get a global space point given the point relativePoint in rigidBody local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetRelativePoint.html")]
	public sealed class Rigidbody2DGetRelativePoint : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The local space point to transform into global space.")]
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
			//UnityEngine.Rigidbody2D.GetRelativePoint(UnityEngine.Vector2);
			_result.Value = _rigidbody2D.Value.GetRelativePoint(_relativePoint.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} relative point {_relativePoint} -> {_result}";
		}
	}
}
