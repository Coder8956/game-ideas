
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision)]
	[ActionDescription("Gets the number of contacts for this collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision-contactCount.html")]
	public sealed class CollisionGetContactCount : BaseAction
	{
		
		[Tooltip("The Collision")]
		[SerializeField]
		private CollisionRef _collision;
		
		[Tooltip("Get Collision Contact Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getContactCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision, _getContactCount);
		}
		
		public override void Execute()
		{
			_getContactCount.Value = _collision.Value.contactCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision} contactCount -> {_getContactCount}";
		}
	}
}
