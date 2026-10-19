
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Specify if this collider is configured as a trigger.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-isTrigger.html")]
	public sealed class ColliderSetIsTrigger : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Is Trigger")]
		[SerializeField]
		private BoolVar _setIsTrigger;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setIsTrigger);
		}
		
		public override void Execute()
		{
			_collider.Value.isTrigger = _setIsTrigger.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} is trigger to {_setIsTrigger}";
		}
	}
}
