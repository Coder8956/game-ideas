
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Contact offset value of this collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider-contactOffset.html")]
	public sealed class ColliderSetContactOffset : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Set Collider Contact Offset")]
		[SerializeField]
		private FloatVar _setContactOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _setContactOffset);
		}
		
		public override void Execute()
		{
			_collider.Value.contactOffset = _setContactOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_collider} contact offset to {_setContactOffset}";
		}
	}
}
