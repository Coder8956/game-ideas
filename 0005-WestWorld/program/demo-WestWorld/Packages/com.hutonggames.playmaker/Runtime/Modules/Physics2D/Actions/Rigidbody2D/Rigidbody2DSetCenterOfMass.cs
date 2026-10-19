
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The center of mass of the rigidBody in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-centerOfMass.html")]
	public sealed class Rigidbody2DSetCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Center Of Mass")]
		[SerializeField]
		private Vector2Var _setCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setCenterOfMass);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.centerOfMass = _setCenterOfMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} center of mass to {_setCenterOfMass}";
		}
	}
}
