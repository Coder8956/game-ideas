
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Casts the Collider shape into the Scene starting at the Collider position ignorin" +
		"g the Collider itself.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.Cast.html")]
	public sealed class Collider2DCast : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Vector representing the direction to cast the shape.")]
		[SerializeField]
		private Vector2Var _direction;

		[Tooltip("Maximum distance over which to cast the shape.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("Ignore colliders attached to the same GameObject as the Collider2D.")]
		[SerializeField]
		[DefaultValue(true)]
		private BoolVar _ignoreSiblings;
		
		[Tooltip("Filter results defined by the contact filter.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("List to receive results.")]
		[SerializeField]
		private RaycastHit2DListRef _results;

		private RaycastHit2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _direction, _contactFilter, _results, _maxDistance, _ignoreSiblings);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.Cast(UnityEngine.Vector2, UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[]);
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = _collider2D.Value.Cast(_direction.Value, _contactFilter.Value, _resultsBuffer, _maxDistance.Value, _ignoreSiblings.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "Cast {_collider2D} {_direction} {_contactFilter} -> {_results} -> {_resultCount}";
		}
	}
}
