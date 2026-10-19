
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("When the value is true, then the shape will use the PhysicsShape2D.adjacentStart|" +
		"adjacentStart feature. When the value is false, then the shape will not use the " +
		"PhysicsShape2D.adjacentEnd|adjacentStart feature.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-useAdjacentStart.html")]
	public sealed class PhysicsShape2DGetUseAdjacentStart : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Use Adjacent Start")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseAdjacentStart;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getUseAdjacentStart);
		}
		
		public override void Execute()
		{
			_getUseAdjacentStart.Value = _physicsShape2D.Value.useAdjacentStart;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} useAdjacentStart -> {_getUseAdjacentStart}";
		}
	}
}
