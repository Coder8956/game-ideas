
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
	public sealed class PhysicsMaterial2DGetBounciness : BaseAction
	{
		
		[Tooltip("The PhysicsMaterial2D")]
		[SerializeField]
		private PhysicsMaterial2DVar _physicsMaterial2D;
		
		[Tooltip("Get PhysicsMaterial2D Bounciness")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBounciness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_physicsMaterial2D, _getBounciness);
		}
		
		public override void Execute()
		{
			_getBounciness.Value = _physicsMaterial2D.Value.bounciness;
		}
		
		public override string GetSummary()
		{
			return "Get {_physicsMaterial2D} bounciness -> {_getBounciness}";
		}
	}
}
