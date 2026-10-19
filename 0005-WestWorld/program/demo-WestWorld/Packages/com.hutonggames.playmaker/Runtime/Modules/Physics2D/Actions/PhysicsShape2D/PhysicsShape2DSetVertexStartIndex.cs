
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("The start index for the geometry of this shape within the PhysicsShapeGroup2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-vertexStartIndex.html")]
	public sealed class PhysicsShape2DSetVertexStartIndex : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Vertex Start Index")]
		[SerializeField]
		private IntegerVar _setVertexStartIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setVertexStartIndex);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.vertexStartIndex = _setVertexStartIndex.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Vertex Start Index to {_setVertexStartIndex}";
		}
	}
}
