
using JetBrains.Annotations;
using UnityEngine;
using System;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Rigidbody2D.isKinematic is obsolete: Please use Rigidbody2D.bodyType instead.")]	
#endif	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a ray into the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.RaycastAll.html")]
	public sealed class Physics2DRaycastAll : BaseAction
	{
		
		[Tooltip("The point in 2D space where the ray originates.")]
		[SerializeField]
		private Vector2Var _origin;
		
		[Tooltip("A vector representing the direction of the ray.")]
		[SerializeField]
		private Vector2Var _direction;

		[Tooltip("The maximum distance over which to cast the ray.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[ActionHeader("Filter")]
		
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
		
		[ActionHeader("Results")]
		
		[Tooltip("Array to receive results.")]
		[SerializeField]
		private RaycastHit2DListRef _results;

		private RaycastHit2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => 
			CheckParameters(_origin, _direction, _maxDistance, _minDepth, _maxDepth, _results);

		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics2D.RaycastNonAlloc(
				_origin.Value, _direction.Value, _resultsBuffer, _maxDistance.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
#endif			
		}
		
		public override string GetSummary()
		{
			return "Physics2D Raycast: {_origin} {_direction} -> {_results} -> {_resultCount}";
		}
	}
}

