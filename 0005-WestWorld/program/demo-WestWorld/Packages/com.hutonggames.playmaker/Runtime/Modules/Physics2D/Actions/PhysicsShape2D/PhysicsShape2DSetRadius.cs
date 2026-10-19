
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
	public sealed class PhysicsShape2DSetRadius : BaseAction
	{
		
		[Tooltip("The PhysicsShape2D")]
		[SerializeField]
		private PhysicsShape2DRef _physicsShape2D;
		
		[Tooltip("Set PhysicsShape2D Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsShape2D, _setRadius);
		}
		
		public override void Execute()
		{
			var value = _physicsShape2D.Value;
			value.radius = _setRadius.Value;
			_physicsShape2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsShape2D} Radius to {_setRadius}";
		}
	}
}
