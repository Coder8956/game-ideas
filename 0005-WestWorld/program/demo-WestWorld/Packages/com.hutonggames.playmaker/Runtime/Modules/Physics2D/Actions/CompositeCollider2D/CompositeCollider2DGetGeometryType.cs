
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Specifies the type of geometry the Composite Collider should generate.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-geometryType.html")]
	public sealed class CompositeCollider2DGetGeometryType : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Geometry Type")]
		[SerializeField]
		[WriteOnly]
		private CompositeCollider2D_GeometryTypeRef _getGeometryType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getGeometryType);
		}
		
		public override void Execute()
		{
			_getGeometryType.Value = _compositeCollider2D.Value.geometryType;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} geometryType -> {_getGeometryType}";
		}
	}
}
