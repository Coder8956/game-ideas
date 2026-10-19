
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Check whether this collider is touching the collider or not with the results filt" +
		"ered by the contactFilter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.IsTouching.html")]
	public sealed class Collider2DIsTouching : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("The collider to check if it is touching this collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _collider, _contactFilter, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.IsTouching(UnityEngine.Collider2D, UnityEngine.ContactFilter2D);
			_result.Value = _collider2D.Value.IsTouching(_collider.Value, _contactFilter.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_collider2D} is touching {_collider} {_contactFilter} -> {_result}";
		}
	}
}
