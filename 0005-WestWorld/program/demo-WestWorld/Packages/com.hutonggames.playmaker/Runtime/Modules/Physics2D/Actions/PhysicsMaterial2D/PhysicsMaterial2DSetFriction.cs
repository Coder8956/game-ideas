
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsMaterial2D)]
	[ActionDescription("Coefficient of friction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PhysicsMaterial2D-friction.html")]
	public sealed class PhysicsMaterial2DSetFriction : BaseAction
	{
		
		[Tooltip("The PhysicsMaterial2D")]
		[SerializeField]
		private PhysicsMaterial2DVar _physicsMaterial2D;
		
		[Tooltip("Set PhysicsMaterial2D Friction")]
		[SerializeField]
		private FloatVar _setFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsMaterial2D, _setFriction);
		}
		
		public override void Execute()
		{
			_physicsMaterial2D.Value.friction = _setFriction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_physicsMaterial2D} Friction to {_setFriction}";
		}
	}
}
