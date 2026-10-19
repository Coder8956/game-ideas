
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
	public sealed class PhysicsShape2DSetUseAdjacentEnd : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Use Adjacent End")]
		[SerializeField]
		private BoolVar _setUseAdjacentEnd;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setUseAdjacentEnd);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.useAdjacentEnd = _setUseAdjacentEnd.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Use Adjacent End to {_setUseAdjacentEnd}";
		}
	}
}
