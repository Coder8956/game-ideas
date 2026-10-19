
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
	public sealed class PhysicsMaterial2DGetFriction : BaseAction
	{
		
		[Tooltip("The PhysicsMaterial2D")]
		[SerializeField]
		private PhysicsMaterial2DVar _physicsMaterial2D;
		
		[Tooltip("Get PhysicsMaterial2D Friction")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFriction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsMaterial2D, _getFriction);
		}
		
		public override void Execute()
		{
			_getFriction.Value = _physicsMaterial2D.Value.friction;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsMaterial2D} friction -> {_getFriction}";
		}
	}
}
