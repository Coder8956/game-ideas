
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results to only include Collider2D with a Z" +
		" coordinate (depth) less than this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-maxDepth.html")]
	public sealed class ContactFilter2DSetMaxDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Max Depth")]
		[SerializeField]
		private FloatVar _setMaxDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setMaxDepth);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.maxDepth = _setMaxDepth.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Max Depth to {_setMaxDepth}";
		}
	}
}
