
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
	public sealed class ColliderGetIsTrigger : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Is Trigger")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsTrigger;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getIsTrigger);
		}
		
		public override void Execute()
		{
			_getIsTrigger.Value = _collider.Value.isTrigger;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} is trigger -> {_getIsTrigger}";
		}
	}
}
