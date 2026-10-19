
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Checks if the angle is within the normal angle range to be filtered.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.IsFilteringNormalAngle.h" +
		"tml")]
	public sealed class ContactFilter2DIsFilteringNormalAngle1 : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The angle used for comparison in the filter.")]
		[SerializeField]
		private FloatVar _angle;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _angle, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.IsFilteringNormalAngle(System.Single);
			_result.Value = _contactFilter2D.Value.IsFilteringNormalAngle(_angle.Value);
		}
		
		public override string GetSummary()
		{
			return "Is Filtering Normal Angle {_contactFilter2D} {_angle} -> {_result}";
		}
	}
}
