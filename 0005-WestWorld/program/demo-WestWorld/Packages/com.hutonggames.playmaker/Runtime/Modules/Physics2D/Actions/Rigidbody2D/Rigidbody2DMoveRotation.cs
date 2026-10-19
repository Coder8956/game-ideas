
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Rotates the Rigidbody to angle (given in degrees).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.MoveRotation.html")]
	public sealed class Rigidbody2DMoveRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The new rotation angle for the Rigidbody object.")]
		[SerializeField]
		private FloatVar _angle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _angle);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.MoveRotation(System.Single);
			_rigidbody2D.Value.MoveRotation(_angle.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_rigidbody2D} rotation to {_angle}";
		}
	}
}
