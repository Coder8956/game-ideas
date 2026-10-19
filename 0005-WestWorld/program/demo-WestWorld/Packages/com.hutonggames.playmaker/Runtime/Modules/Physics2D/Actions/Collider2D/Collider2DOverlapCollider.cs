
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Get a list of all colliders that overlap this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.Overlap.html")]
	public sealed class Collider2DOverlapCollider : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask, " +
			"Z depth.  Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("The list to receive results.  The size of the list determines the maximum number " +
			"of results that can be returned.")]
		[SerializeField, OptionalField, WriteOnly]
		private Collider2DListRef _results;
		
		[Tooltip("Store the number of colliders result in Integer variable.")]
		[SerializeField]
		[WriteOnly, OptionalField]
		private IntegerRef _colliderCount;
		
		public override bool CanExecute() => CheckParameters(_collider2D, _contactFilter);

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_colliderCount.Value = _collider2D.Value.Overlap(_contactFilter.Value, _results.Value);
#else
			_colliderCount.Value = _collider2D.Value.OverlapCollider(_contactFilter.Value, _results.Value);
#endif
		}
		
		public override string GetSummary()
		{
			return "Check {_collider2D} overlap {_contactFilter} {_results:output} {_colliderCount:output}";
		}
	}
}

