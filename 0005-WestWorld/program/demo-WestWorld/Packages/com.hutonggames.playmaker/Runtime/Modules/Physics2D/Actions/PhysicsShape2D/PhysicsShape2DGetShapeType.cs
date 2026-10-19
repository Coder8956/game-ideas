
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("The shape type determines how the vertices and radius are used by this PhysicsSha" +
		"pe2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-shapeType.html")]
	public sealed class PhysicsShape2DGetShapeType : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Shape Type")]
		[SerializeField]
		[WriteOnly]
		private PhysicsShapeType2DRef _getShapeType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getShapeType);
		}
		
		public override void Execute()
		{
			_getShapeType.Value = _physicsShape2D.Value.shapeType;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} shapeType -> {_getShapeType}";
		}
	}
}
