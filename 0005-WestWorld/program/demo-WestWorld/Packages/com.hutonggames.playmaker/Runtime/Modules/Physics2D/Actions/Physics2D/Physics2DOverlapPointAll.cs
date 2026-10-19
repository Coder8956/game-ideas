
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider overlaps a point in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapPoint.html")]
	public sealed class Physics2DOverlapPointAll : BaseAction
	{
		
		[Tooltip("A point in world space.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth. Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("The list to receive results. The size of the array determines the maximum number" +
			" of results that can be returned.")]
		[SerializeField]
		private Collider2DListRef _results;

		private Collider2D[] _resultsBuffer;
		
		[WriteOnly]
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => CheckParameters(_point, _contactFilter, _results);

		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics2D.OverlapPoint(_point.Value, _contactFilter.Value, _resultsBuffer);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned)
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary() => 
			"Physics2D Overlap Point: {_point} {_contactFilter} -> {_results} -> {_resultCount}";
	}
}
