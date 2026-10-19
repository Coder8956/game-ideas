
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Controls the radius of all edges created by the Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-edgeRadius.html")]
	public sealed class CompositeCollider2DGetEdgeRadius : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Edge Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getEdgeRadius);
		}
		
		public override void Execute()
		{
			_getEdgeRadius.Value = _compositeCollider2D.Value.edgeRadius;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} edgeRadius -> {_getEdgeRadius}";
		}
	}
}
