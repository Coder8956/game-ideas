
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
	public sealed class BoxCollider2DGetEdgeRadius : BaseAction
	{
		
		[Tooltip("The BoxCollider2D")]
		[SerializeField]
		private BoxCollider2DVar _boxCollider2D;
		
		[Tooltip("Get BoxCollider2D Edge Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_boxCollider2D, _getEdgeRadius);
		}
		
		public override void Execute()
		{
			_getEdgeRadius.Value = _boxCollider2D.Value.edgeRadius;
		}
		
		public override string GetSummary()
		{
			return "Get {_boxCollider2D} edgeRadius -> {_getEdgeRadius}";
		}
	}
}
