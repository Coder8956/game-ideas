
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("Defines the position of a virtual point adjacent to the end vertex of an edge sha" +
		"pe.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-adjacentEnd.html")]
	public sealed class PhysicsShape2DGetAdjacentEnd : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Adjacent End")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAdjacentEnd;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getAdjacentEnd);
		}
		
		public override void Execute()
		{
			_getAdjacentEnd.Value = _physicsShape2D.Value.adjacentEnd;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} adjacentEnd -> {_getAdjacentEnd}";
		}
	}
}
