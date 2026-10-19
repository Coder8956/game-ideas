
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Get a list of all Colliders that fall within a box area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapBox.html")]
	public sealed class Physics2DOverlapBoxAll : BaseAction
	{
		
		[Tooltip("The center of the box.")]
		[SerializeField]
		private Vector2Var _point;
		
		[Tooltip("The size of the box.")]
		[SerializeField]
		private Vector2Var _size;
		
		[Tooltip("The angle of the box.")]
		[SerializeField]
		private FloatVar _angle;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
		         " Z depth.  Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("Store the result in Collider2D List variable.")]
		[SerializeField]
		[WriteOnly]
		private Collider2DListRef _results;

		private Collider2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => 
			CheckParameters(_point, _size, _angle, _contactFilter, _results);

		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = Physics2D.OverlapBox(_point.Value, _size.Value, _angle.Value,  _contactFilter.Value, _resultsBuffer);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned)
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary() => 
			"Physics2D Overlap Box All: {_point} {_size} {_angle} -> {_results}";
	}
}
