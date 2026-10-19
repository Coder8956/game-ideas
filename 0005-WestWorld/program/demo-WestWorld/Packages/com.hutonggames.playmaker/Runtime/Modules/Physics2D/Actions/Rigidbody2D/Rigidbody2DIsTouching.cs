
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Checks whether any collider is touching any of the collider(s) attached to this r" +
		"igidbody or not with the results filtered by the ContactFilter2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.IsTouching.html")]
	public sealed class Rigidbody2DIsTouching : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
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
			return CheckParameters(_rigidbody2D, _contactFilter, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.IsTouching(UnityEngine.ContactFilter2D);
			_result.Value = _rigidbody2D.Value.IsTouching(_contactFilter.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_rigidbody2D} is touching {_contactFilter} -> {_result}";
		}
	}
}
