
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Controls the radius of all edges created by the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-edgeRadius.html")]
	public sealed class EdgeCollider2DSetEdgeRadius : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Set EdgeCollider2D Edge Radius")]
		[SerializeField]
		private FloatVar _setEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _setEdgeRadius);
		}
		
		public override void Execute()
		{
			_edgeCollider2D.Value.edgeRadius = _setEdgeRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_edgeCollider2D} Edge Radius to {_setEdgeRadius}";
		}
	}
}
