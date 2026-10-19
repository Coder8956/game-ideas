
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
	public sealed class CompositeCollider2DGetVertexDistance : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Vertex Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getVertexDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getVertexDistance);
		}
		
		public override void Execute()
		{
			_getVertexDistance.Value = _compositeCollider2D.Value.vertexDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} vertexDistance -> {_getVertexDistance}";
		}
	}
}
