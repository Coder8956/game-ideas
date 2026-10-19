
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Cast a ray through the Scene and store the hits into the buffer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.RaycastNonAlloc.html")]
	public sealed class PhysicsRaycastNonAlloc : BaseAction
	{
		
		[Tooltip("The starting point and direction of the ray.")]
		[SerializeField]
		private Vector3Var _origin;
		
		[Tooltip("The direction of the ray.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The maximum distance the ray should check for collisions. Set to -1 for infinity.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("A Layer mask that is used to selectively ignore colliders when casting a ray.")]
		[SerializeField]
		[DefaultValue("Physics.DefaultRaycastLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Specifies whether this query should hit Triggers.")]
		[DefaultValue(QueryTriggerInteraction.UseGlobal)]
		[SerializeField]
		private QueryTriggerInteraction _hitTriggers;
		
		[Tooltip("The buffer to store the hits into.")]
		[SerializeField]
		private RaycastHitListRef _results;

		private RaycastHit[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_origin, _direction, _maxDistance, _layerMask, _results);
		}
		
		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics.RaycastNonAlloc(_origin.Value, _direction.Value, _resultsBuffer, _maxDistance.Value, _layerMask.Value, _hitTriggers);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.HasValue())
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary()
		{
			return "Raycast Non Alloc from {_origin} in {_direction} using {_maxDistance} {_layerMask} {_results} {_resultCount:output}";
		}
	}
}
