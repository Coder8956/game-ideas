
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Given the current state of the contact filter, determine whether it would filter " +
		"anything.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-isFiltering.html")]
	public sealed class ContactFilter2DGetIsFiltering : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Is Filtering")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsFiltering;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getIsFiltering);
		}
		
		public override void Execute()
		{
			_getIsFiltering.Value = _contactFilter2D.Value.isFiltering;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} isFiltering -> {_getIsFiltering}";
		}
	}
}
