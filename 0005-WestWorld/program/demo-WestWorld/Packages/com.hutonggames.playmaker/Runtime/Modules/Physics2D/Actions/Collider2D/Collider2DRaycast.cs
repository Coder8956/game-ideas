
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Casts a ray into the Scene that starts at the Collider position and ignores the Collider itself.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.Raycast.html")]
	public sealed class Collider2DRaycast : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Vector representing the direction of the ray.")]
		[SerializeField]
		private Vector2Var _direction;
		
		[Tooltip("The maximum distance over which to cast the ray.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("Filter results defined by the contact filter.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("List to receive results.")]
		[SerializeField]
		private RaycastHit2DListRef _results;

		private RaycastHit2D[] _resultsBuffer;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => CheckParameters(_collider2D, _direction, _maxDistance, _contactFilter, _results, _resultCount);

		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = _collider2D.Value.Raycast(_direction.Value, _contactFilter.Value, _resultsBuffer, _maxDistance.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount != null)
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary() => "Raycast {_collider2D} {_direction} {_contactFilter} -> {_results} -> {_resultCount}";
	}
}
