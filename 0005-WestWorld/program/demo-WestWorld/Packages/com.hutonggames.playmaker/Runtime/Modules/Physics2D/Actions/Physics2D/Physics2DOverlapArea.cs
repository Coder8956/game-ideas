
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider falls within a rectangular area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapArea.html")]
	public sealed class Physics2DOverlapArea : BaseAction
	{
		
		[Tooltip("One corner of the rectangle.")]
		[SerializeField]
		private Vector2Var _pointA;
		
		[Tooltip("Diagonally opposite the point A corner of the rectangle.")]
		[SerializeField]
		private Vector2Var _pointB;
		
		[ActionHeader("Filters")]
		
		[Tooltip("Filter to check objects only on specific layers.")]
		[SerializeField]
		[DefaultValue("~Physics2DDefaultRaycastLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatNegativeInfinity")]
		private FloatVar _minDepth;
		
		[Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatPositiveInfinity")]
		private FloatVar _maxDepth;
		
		[ActionHeader("Result")]
		
		[Tooltip("Store the result in Collider2D variable.")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _result;
		
		public override bool CanExecute() => 
			CheckParameters(_pointA, _pointB, _layerMask, _minDepth, _maxDepth, _result);

		public override void Execute()
		{
			//UnityEngine.Physics2D.OverlapArea(UnityEngine.Vector2, UnityEngine.Vector2, System.Int32);
			_result.Value = Physics2D.OverlapArea(
				_pointA.Value, _pointB.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary() => 
			"Physics2D Overlap Area: {_pointA} {_pointB} {_layerMask} -> {_result}";
	}
}
