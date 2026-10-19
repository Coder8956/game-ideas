
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collision2D)]
	[ActionDescription("Gets the number of contacts for this collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collision2D-contactCount.html")]
	public sealed class Collision2DGetContactCount : BaseAction
	{
		
		[Tooltip("The Collision2D")]
		[SerializeField]
		private Collision2DRef _collision2D;
		
		[Tooltip("Get Collision2D Contact Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getContactCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collision2D, _getContactCount);
		}
		
		public override void Execute()
		{
			_getContactCount.Value = _collision2D.Value.contactCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_collision2D} contactCount -> {_getContactCount}";
		}
	}
}
