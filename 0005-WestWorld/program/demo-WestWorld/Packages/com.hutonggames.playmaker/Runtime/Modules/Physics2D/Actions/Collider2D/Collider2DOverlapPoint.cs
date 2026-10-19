
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Check if a collider overlaps a point in space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.OverlapPoint.html")]
	public sealed class Collider2DOverlapPoint : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("A point in world space.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _point, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.OverlapPoint(UnityEngine.Vector2);
			_result.Value = _collider2D.Value.OverlapPoint(_point.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_collider2D} overlap {_point} -> {_result}";
		}
	}
}
