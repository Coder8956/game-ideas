
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider falls within a circular area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html")]
	public sealed class Physics2DOverlapCircle : BaseAction
	{
		
		[Tooltip("Centre of the circle.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("The radius of the circle.")]
		[SerializeField]
		private FloatVar _radius;
		
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
		
		public override bool CanExecute() => CheckParameters(_point, _radius, _layerMask, _minDepth, _maxDepth, _result);

		public override void Execute() => 
			_result.Value = Physics2D.OverlapCircle(
				_point.Value, _radius.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);

		public override string GetSummary() => "Physics2D Overlap Circle: {_point} {_radius} -> {_result}";
	}
}
