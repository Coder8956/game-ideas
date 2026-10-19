
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
	public sealed class ColliderGetEnabled : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _collider.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} enabled -> {_getEnabled}";
		}
	}
}
