
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
	public sealed class EdgeCollider2DGetEdgeRadius : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Edge Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getEdgeRadius);
		}
		
		public override void Execute()
		{
			_getEdgeRadius.Value = _edgeCollider2D.Value.edgeRadius;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} edgeRadius -> {_getEdgeRadius}";
		}
	}
}
