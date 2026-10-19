
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.BoxCollider2D)]
	[ActionDescription("Controls the radius of all edges created by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/BoxCollider2D-edgeRadius.html")]
	public sealed class BoxCollider2DSetEdgeRadius : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Set BoxCollider2D Edge Radius")]
		[SerializeField]
		private FloatVar _setEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _setEdgeRadius);
		}
		
		public override void Execute()
		{
			_boxCollider2D.Value.edgeRadius = _setEdgeRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_boxCollider2D} Edge Radius to {_setEdgeRadius}";
		}
	}
}
