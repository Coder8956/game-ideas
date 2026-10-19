
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsShape2D)]
	[ActionDescription("The radius of the shape.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsShape2D-radius.html")]
	public sealed class PhysicsShape2DGetRadius : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Get PhysicsShape2D Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _physicsShape2D.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsShape2D} radius -> {_getRadius}";
		}
	}
}
