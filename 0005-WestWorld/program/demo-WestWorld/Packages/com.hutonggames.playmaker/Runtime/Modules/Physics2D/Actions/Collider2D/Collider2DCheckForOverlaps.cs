
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Check if a Collider2D has any overlaps.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.Overlap.html")]
	[System.Serializable]
	public sealed class Collider2DCheckForOverlaps : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;

		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth.  Note that normal angle is not used for overlap testing.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		private List<Collider2D> _results = new();
		
		public override bool CanExecute() => CheckParameters(_collider2D, _contactFilter) && base.CanExecute();

		protected override bool Test()
		{
#if UNITY_6000_0_OR_NEWER
			var numResults = _collider2D.Value.Overlap(_contactFilter.Value, _results);
#else
			var numResults = _collider2D.Value.OverlapCollider(_contactFilter.Value, _results);
#endif
			return numResults > 0;
		}

		protected override string TrueSummary => "{_collider2D} has overlaps";
		protected override string FalseSummary => "{_collider2D} has no overlaps";
	}
}
