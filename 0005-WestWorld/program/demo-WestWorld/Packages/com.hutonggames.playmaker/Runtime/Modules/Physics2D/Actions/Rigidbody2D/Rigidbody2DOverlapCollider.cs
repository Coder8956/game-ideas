
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get a list of all Colliders that overlap all Colliders attached to this Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.Overlap.html")]
	public sealed class Rigidbody2DOverlapCollider : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth.  Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("The array to receive results.  The size of the array determines the maximum numbe" +
			"r of results that can be returned.")]
		[SerializeField]
		private Collider2DListRef _results;

		private Collider2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _contactFilter, _results);
		}
		
		public override void Execute()
		{
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

#if UNITY_6000_0_OR_NEWER
			var resultCount = _rigidbody2D.Value.Overlap(_contactFilter.Value, _resultsBuffer);
#else
			var resultCount = _rigidbody2D.Value.OverlapCollider(_contactFilter.Value, _resultsBuffer);
#endif
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned) _resultCount.Value = resultCount;
		}
		
		public override string GetSummary()
		{
			return "Check {_rigidbody2D} overlap collider {_contactFilter} -> {_results}";
		}
	}
}

