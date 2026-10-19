
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
	public sealed class PhysicsShape2DSetUseAdjacentStart : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Use Adjacent Start")]
		[SerializeField]
		private BoolVar _setUseAdjacentStart;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setUseAdjacentStart);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.useAdjacentStart = _setUseAdjacentStart.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Use Adjacent Start to {_setUseAdjacentStart}";
		}
	}
}
