
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
	public sealed class CompositeCollider2DSetEdgeRadius : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Edge Radius")]
		[SerializeField]
		private FloatVar _setEdgeRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setEdgeRadius);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.edgeRadius = _setEdgeRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Edge Radius to {_setEdgeRadius}";
		}
	}
}
