
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("Defines the position of a virtual point adjacent to the start vertex of an edge s" +
		"hape.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-adjacentStart.html")]
	public sealed class PhysicsShape2DGetAdjacentStart : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Adjacent Start")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAdjacentStart;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getAdjacentStart);
		}
		
		public override void Execute()
		{
			_getAdjacentStart.Value = _physicsShape2D.Value.adjacentStart;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} adjacentStart -> {_getAdjacentStart}";
		}
	}
}
