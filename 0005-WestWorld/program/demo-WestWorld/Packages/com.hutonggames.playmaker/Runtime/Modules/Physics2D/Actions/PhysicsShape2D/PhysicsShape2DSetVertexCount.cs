
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("The total number of vertices used to represent the PhysicsShape2D.shapeType|shape" +
		" type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-vertexCount.html")]
	public sealed class PhysicsShape2DSetVertexCount : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Vertex Count")]
		[SerializeField]
		private IntegerVar _setVertexCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setVertexCount);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.vertexCount = _setVertexCount.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Vertex Count to {_setVertexCount}";
		}
	}
}
