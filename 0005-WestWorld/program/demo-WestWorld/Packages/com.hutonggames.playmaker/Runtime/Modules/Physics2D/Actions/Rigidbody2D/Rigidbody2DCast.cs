
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("All the Collider2D shapes attached to the Rigidbody2D are cast into the Scene sta" +
		"rting at each Collider position ignoring the Colliders attached to the same Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.Cast.html")]
	public sealed class Rigidbody2DCast : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Vector representing the direction to cast each Collider2D shape.")]
		[SerializeField]
		private Vector2Var _direction;
		
		[Tooltip("Maximum distance over which to cast the Collider(s).")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("Filter results defined by the contact filter.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("Array to receive results.")]
		[SerializeField]
		private RaycastHit2DListRef _results;

		private RaycastHit2D[] _resultsBuffer;
		
		[WriteOnly]
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => CheckParameters(
			_rigidbody2D, _direction, _maxDistance, _contactFilter, _results);

		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.Cast(UnityEngine.Vector2, UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[]);
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = _rigidbody2D.Value.Cast(
				_direction.Value, _contactFilter.Value, _resultsBuffer, _maxDistance.Value);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned)
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary() => 
			"Cast {_rigidbody2D} {_direction} {_contactFilter} -> {_results} -> {_resultCount}";
	}
}
