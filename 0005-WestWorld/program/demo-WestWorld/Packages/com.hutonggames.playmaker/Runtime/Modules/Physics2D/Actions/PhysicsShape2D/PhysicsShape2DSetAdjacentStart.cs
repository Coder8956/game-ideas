
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
	public sealed class PhysicsShape2DSetAdjacentStart : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Adjacent Start")]
		[SerializeField]
		private Vector2Var _setAdjacentStart;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setAdjacentStart);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.adjacentStart = _setAdjacentStart.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Adjacent Start to {_setAdjacentStart}";
		}
	}
}
