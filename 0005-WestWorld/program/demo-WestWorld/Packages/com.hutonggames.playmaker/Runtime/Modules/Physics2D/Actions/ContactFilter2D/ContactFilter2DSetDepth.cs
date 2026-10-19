
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the minDepth and maxDepth filter properties and turns on depth filtering by " +
		"setting useDepth to true.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.SetDepth.html")]
	public sealed class ContactFilter2DSetDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The value used to set minDepth.")]
		[SerializeField]
		private FloatVar _minDepth;
		
		[Tooltip("The value used to set maxDepth.")]
		[SerializeField]
		private FloatVar _maxDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _minDepth, _maxDepth);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.SetDepth(System.Single, System.Single);
			_contactFilter2D.Value.SetDepth(_minDepth.Value, _maxDepth.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Depth {_contactFilter2D} {_minDepth} {_maxDepth} ";
		}
	}
}
