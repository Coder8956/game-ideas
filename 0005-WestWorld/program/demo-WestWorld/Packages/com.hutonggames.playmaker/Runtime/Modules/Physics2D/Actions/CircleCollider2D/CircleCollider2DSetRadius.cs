
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CircleCollider2D)]
	[ActionDescription("Radius of the circle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CircleCollider2D-radius.html")]
	public sealed class CircleCollider2DSetRadius : BaseAction
	{
		
		[Tooltip("The CircleCollider2D")]
		[SerializeField]
		private CircleCollider2DVar _circleCollider2D;
		
		[Tooltip("Set CircleCollider2D Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_circleCollider2D, _setRadius);
		}
		
		public override void Execute()
		{
			_circleCollider2D.Value.radius = _setRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_circleCollider2D} Radius to {_setRadius}";
		}
	}
}
