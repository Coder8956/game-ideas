
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks if a Collider is touching any other Collider filtered by a contactFilter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.IsTouching.html")]
	public sealed class Physics2DIsTouching : BaseAction
	{
		
		[Tooltip("Collider.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("Whether the Collider is touching any other Collider filtered by the contactFilter or not.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_collider, _contactFilter, _result);

		public override void Execute() => _result.Value = Physics2D.IsTouching(_collider.Value, _contactFilter.Value);

		public override string GetSummary() => "{_collider} Is Touching {_contactFilter} -> {_result}";
	}
}
