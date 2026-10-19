
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
	public sealed class PhysicsShape2DGetVertexCount : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Vertex Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getVertexCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getVertexCount);
		}
		
		public override void Execute()
		{
			_getVertexCount.Value = _physicsShape2D.Value.vertexCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} vertexCount -> {_getVertexCount}";
		}
	}
}
