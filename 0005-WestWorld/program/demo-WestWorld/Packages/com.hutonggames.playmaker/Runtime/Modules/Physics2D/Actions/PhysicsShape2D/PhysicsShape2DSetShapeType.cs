
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
	public sealed class PhysicsShape2DSetShapeType : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Shape Type")]
		[SerializeField]
		private PhysicsShapeType2DVar _setShapeType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setShapeType);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.shapeType = _setShapeType.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Shape Type to {_setShapeType}";
		}
	}
}
