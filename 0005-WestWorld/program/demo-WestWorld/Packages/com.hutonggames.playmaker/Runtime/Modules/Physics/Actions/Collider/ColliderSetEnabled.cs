
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Enabled Colliders will collide with other Colliders, disabled Colliders won\'t.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-enabled.html")]
	public sealed class ColliderSetEnabled : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Enabled")]
		[SerializeField]
		private BoolVar _setEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setEnabled);
		}
		
		public override void Execute()
		{
			_collider.Value.enabled = _setEnabled.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} enabled to {_setEnabled}";
		}
	}
}
