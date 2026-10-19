
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
	public sealed class CircleCollider2DGetRadius : BaseAction
	{
		
		[Tooltip("The CircleCollider2D")]
		[SerializeField]
		private CircleCollider2DVar _circleCollider2D;
		
		[Tooltip("Get CircleCollider2D Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_circleCollider2D, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _circleCollider2D.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_circleCollider2D} radius -> {_getRadius}";
		}
	}
}
