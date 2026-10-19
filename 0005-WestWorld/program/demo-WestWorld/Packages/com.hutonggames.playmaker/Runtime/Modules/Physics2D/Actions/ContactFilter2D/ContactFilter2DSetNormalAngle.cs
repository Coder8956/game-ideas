
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the minNormalAngle and maxNormalAngle filter properties and turns on normal " +
		"angle filtering by setting useNormalAngle to true.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.SetNormalAngle.html")]
	public sealed class ContactFilter2DSetNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The value used to set the minNormalAngle.")]
		[SerializeField]
		private FloatVar _minNormalAngle;
		
		[Tooltip("The value used to set the maxNormalAngle.")]
		[SerializeField]
		private FloatVar _maxNormalAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _minNormalAngle, _maxNormalAngle);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.SetNormalAngle(System.Single, System.Single);
			_contactFilter2D.Value.SetNormalAngle(_minNormalAngle.Value, _maxNormalAngle.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Normal Angle {_contactFilter2D} {_minNormalAngle} {_maxNormalAngle} ";
		}
	}
}
