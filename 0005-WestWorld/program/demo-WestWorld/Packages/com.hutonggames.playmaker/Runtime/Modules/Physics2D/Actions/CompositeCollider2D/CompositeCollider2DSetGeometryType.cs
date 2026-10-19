
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Specifies the type of geometry the Composite Collider should generate.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-geometryType.html")]
	public sealed class CompositeCollider2DSetGeometryType : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Geometry Type")]
		[SerializeField]
		private CompositeCollider2D_GeometryTypeVar _setGeometryType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setGeometryType);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.geometryType = _setGeometryType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Geometry Type to {_setGeometryType}";
		}
	}
}
