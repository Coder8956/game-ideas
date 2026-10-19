
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsMaterial2D)]
	[ActionDescription("The degree of elasticity during collisions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial2D-bounciness.html")]
	public sealed class PhysicsMaterial2DSetBounciness : BaseAction
	{
		
		[Tooltip("The PhysicsMaterial2D")]
		[SerializeField]
		private PhysicsMaterial2DVar _physicsMaterial2D;
		
		[Tooltip("Set PhysicsMaterial2D Bounciness")]
		[SerializeField]
		private FloatVar _setBounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsMaterial2D, _setBounciness);
		}
		
		public override void Execute()
		{
			_physicsMaterial2D.Value.bounciness = _setBounciness.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsMaterial2D} Bounciness to {_setBounciness}";
		}
	}
}
