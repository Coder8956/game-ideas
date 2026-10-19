
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Checks whether the passed Colliders are in contact or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.IsTouching.html")]
	public sealed class Physics2DIsTouchingCollider : BaseAction
	{
		
		[Tooltip("The Collider to check if it is touching collider2.")]
		[SerializeField]
		private Collider2DVar _collider1;
		
		[Tooltip("The Collider to check if it is touching collider1.")]
		[SerializeField]
		private Collider2DVar _collider2;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
			" Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_collider1, _collider2, _contactFilter, _result);

		public override void Execute()
		{
			_result.Value = Physics2D.IsTouching(_collider1.Value, _collider2.Value, _contactFilter.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Is Touching: {_collider1} {_collider2} {_contactFilter} -> {_result}";
		}
	}
}
