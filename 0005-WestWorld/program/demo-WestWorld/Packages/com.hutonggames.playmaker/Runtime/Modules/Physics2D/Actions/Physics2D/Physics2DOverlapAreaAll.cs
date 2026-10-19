
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Get a list of all Colliders that fall within a specified area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.OverlapArea.html")]
	public sealed class Physics2DOverlapAreaAll : BaseAction
	{
		
		[Tooltip("One corner of the rectangle.")]
		[SerializeField]
		private Vector2Var _pointA;
		
		[Tooltip("Diagonally opposite the point A corner of the rectangle.")]
		[SerializeField]
		private Vector2Var _pointB;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
		         " Z depth.  Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;

		[Tooltip("List to receive results.")]
		[SerializeField]
		private Collider2DListRef _results;
		
        [OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => 
			CheckParameters(_pointA, _pointB, _contactFilter, _results);

		public override void Execute()
		{
			var resultCount = Physics2D.OverlapArea(
				_pointA.Value, _pointB.Value, _contactFilter.Value, _results.Value);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary() => 
			"Physics2D Overlap Area Non Alloc: {_pointA} {_pointB} -> {_results} -> {_resultCount}";
	}
}
