
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Creates as regular primitive polygon with the specified number of sides.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D.CreatePrimitive.html")]
	public sealed class PolygonCollider2DCreatePrimitive : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D.")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("The number of sides in the polygon. This must be greater than two.")]
		[SerializeField]
		private IntegerVar _sides;
		
		[Tooltip("The X/Y scale of the polygon. These must be greater than zero.")]
		[SerializeField]
		[DefaultValue("Vector2.one")]
		private Vector2Var _scale;
		
		[Tooltip("The X/Y offset of the polygon.")]
		[SerializeField]
		private Vector2Var _offset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _sides, _scale, _offset);
		}
		
		public override void Execute()
		{
			//UnityEngine.PolygonCollider2D.CreatePrimitive(System.Int32, UnityEngine.Vector2, UnityEngine.Vector2);
			_polygonCollider2D.Value.CreatePrimitive(_sides.Value, _scale.Value, _offset.Value);
		}
		
		public override string GetSummary()
		{
			return "Create Primitive {_polygonCollider2D} {_sides} {_scale} {_offset} ";
		}
	}
}
