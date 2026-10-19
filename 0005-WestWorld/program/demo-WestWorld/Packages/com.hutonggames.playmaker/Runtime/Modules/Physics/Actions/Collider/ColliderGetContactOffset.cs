
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
	public sealed class ColliderGetContactOffset : BaseAction
	{
		
		[Tooltip("The Collider")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Get Collider Contact Offset")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getContactOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _getContactOffset);
		}
		
		public override void Execute()
		{
			_getContactOffset.Value = _collider.Value.contactOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_collider} contact offset -> {_getContactOffset}";
		}
	}
}
