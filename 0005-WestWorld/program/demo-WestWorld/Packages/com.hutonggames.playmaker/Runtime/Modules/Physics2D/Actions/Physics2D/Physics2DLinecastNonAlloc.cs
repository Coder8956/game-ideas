
using JetBrains.Annotations;
using UnityEngine;
using System;

namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_0_OR_NEWER
	[Obsolete("Physics2D.LinecastNonAlloc is deprecated. Use Physics2D.Linecast instead.")]	
#endif	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a line against Colliders in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.Linecast.html")]
	public sealed class Physics2DLinecastNonAlloc : BaseAction
	{
		
		[Tooltip("The start point of the line in world space.")]
		[SerializeField]
		private Vector2Var _start;
		
		[Tooltip("The end point of the line in world space.")]
		[SerializeField]
		private Vector2Var _end;
		
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
		
		[Tooltip("Store the results in RaycastHit2D List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHit2DListRef _results;

		private RaycastHit2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _layerMask, _minDepth, _maxDepth, _results);
		}
		
		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics2D.LinecastNonAlloc(_start.Value, _end.Value, _resultsBuffer, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
#endif
		}
		
		public override string GetSummary()
		{
			return "Physics2D Linecast: {_start} {_end} {_layerMask} -> {_results}";
		}
	}
}

