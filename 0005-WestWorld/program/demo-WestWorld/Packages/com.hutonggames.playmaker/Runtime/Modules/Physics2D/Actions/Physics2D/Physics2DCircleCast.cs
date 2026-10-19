
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI, Serializable]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a circle against Colliders in the Scene, returning the first Collider that contacts with it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.CircleCast.html")]
	public sealed class Physics2DCircleCast : BaseAction
	{
		
		[Tooltip("The point in 2D space where the circle originates.")]
		[SerializeField]
		private Vector2Var _origin;
		
		[Tooltip("The radius of the circle.")]
		[SerializeField]
		[DefaultValue(1f)]
		private FloatVar _radius;
		
		[Tooltip("A vector representing the direction of the circle.")]
		[SerializeField]
		private Vector2Var _direction;
		
		[Tooltip("The maximum distance over which to cast the circle.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
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
		
		[WriteOnly]
		[Tooltip("Store the result in RaycastHit2D List variable.")]
		[SerializeField]
		private RaycastHit2DRef _result;
		
		public override bool CanExecute() => 
			CheckParameters(_origin, _radius, _direction, _maxDistance, _layerMask, _minDepth, _maxDepth, _result);

		public override void Execute()
		{
			_result.Value = Physics2D.CircleCast(
				_origin.Value, _radius.Value, _direction.Value, _maxDistance.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary() => 
			"Physics2D Circle Cast All: {_origin} {_radius} {_direction} -> {_result}";
	}
}
