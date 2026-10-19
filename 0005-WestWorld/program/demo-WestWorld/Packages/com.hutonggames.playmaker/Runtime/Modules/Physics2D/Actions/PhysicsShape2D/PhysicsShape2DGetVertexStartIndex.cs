
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
	public sealed class PhysicsShape2DGetVertexStartIndex : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Vertex Start Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getVertexStartIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getVertexStartIndex);
		}
		
		public override void Execute()
		{
			_getVertexStartIndex.Value = _physicsShape2D.Value.vertexStartIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} vertexStartIndex -> {_getVertexStartIndex}";
		}
	}
}
