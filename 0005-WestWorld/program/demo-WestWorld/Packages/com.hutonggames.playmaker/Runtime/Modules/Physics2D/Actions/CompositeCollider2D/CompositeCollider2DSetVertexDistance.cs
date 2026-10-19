
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Controls the minimum distance allowed between generated vertices.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-vertexDistance.html")]
	public sealed class CompositeCollider2DSetVertexDistance : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Vertex Distance")]
		[SerializeField]
		private FloatVar _setVertexDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setVertexDistance);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.vertexDistance = _setVertexDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Vertex Distance to {_setVertexDistance}";
		}
	}
}
