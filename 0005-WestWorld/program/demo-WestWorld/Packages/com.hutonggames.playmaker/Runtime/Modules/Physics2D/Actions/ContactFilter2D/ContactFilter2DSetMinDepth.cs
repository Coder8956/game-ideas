
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include Collider2D with a Z" +
		" coordinate (depth) greater than this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-minDepth.html")]
	public sealed class ContactFilter2DSetMinDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Min Depth")]
		[SerializeField]
		private FloatVar _setMinDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setMinDepth);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.minDepth = _setMinDepth.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Min Depth to {_setMinDepth}";
		}
	}
}
