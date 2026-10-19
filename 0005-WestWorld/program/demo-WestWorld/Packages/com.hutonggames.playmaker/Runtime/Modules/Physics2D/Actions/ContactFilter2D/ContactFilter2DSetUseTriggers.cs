
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets to filter contact results based on trigger collider involvement.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-useTriggers.html")]
	public sealed class ContactFilter2DSetUseTriggers : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Use Triggers")]
		[SerializeField]
		private BoolVar _setUseTriggers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setUseTriggers);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.useTriggers = _setUseTriggers.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Use Triggers to {_setUseTriggers}";
		}
	}
}
