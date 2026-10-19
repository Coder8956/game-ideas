
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
	public sealed class PhysicsShape2DSetAdjacentEnd : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Adjacent End")]
		[SerializeField]
		private Vector2Var _setAdjacentEnd;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setAdjacentEnd);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.adjacentEnd = _setAdjacentEnd.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Adjacent End to {_setAdjacentEnd}";
		}
	}
}
