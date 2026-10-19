
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("The number of active PhysicsShape2D the Collider2D is currently using.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D-shapeCount.html")]
	public sealed class Collider2DGetShapeCount : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Shape Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getShapeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getShapeCount);
		}
		
		public override void Execute()
		{
			_getShapeCount.Value = _collider2D.Value.shapeCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} shape count -> {_getShapeCount}";
		}
	}
}
