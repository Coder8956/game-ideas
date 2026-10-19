
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("When the value is true, then the shape will use the PhysicsShape2D.adjacentEnd|ad" +
		"jacentEnd feature. When the value is false, then the shape will not use the Phys" +
		"icsShape2D.adjacentEnd|adjacentEnd feature.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-useAdjacentEnd.html")]
	public sealed class PhysicsShape2DGetUseAdjacentEnd : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Use Adjacent End")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseAdjacentEnd;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getUseAdjacentEnd);
		}
		
		public override void Execute()
		{
			_getUseAdjacentEnd.Value = _physicsShape2D.Value.useAdjacentEnd;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} useAdjacentEnd -> {_getUseAdjacentEnd}";
		}
	}
}
