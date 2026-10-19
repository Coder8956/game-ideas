
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Computes and stores colliders touching or inside the sphere into the provided buffer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.OverlapSphereNonAlloc.html")]
	public sealed class PhysicsOverlapSphereNonAlloc : BaseAction
	{
		
		[Tooltip("Center of the sphere.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Radius of the sphere.")]
		[SerializeField]
		private FloatVar _radius;
		
		[Tooltip("A Layer mask defines which layers of colliders to include in the query.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("The buffer to store the results into.")]
		[SerializeField]
		private ColliderListRef _results;

		private Collider[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_position, _radius, _layerMask, _results);
		}
		
		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics.OverlapSphereNonAlloc(_position.Value, _radius.Value, _resultsBuffer, _layerMask.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.HasValue())
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary()
		{
			return "Overlap sphere {_position} {_radius} {_layerMask} -> {_results}";
		}
	}
}
