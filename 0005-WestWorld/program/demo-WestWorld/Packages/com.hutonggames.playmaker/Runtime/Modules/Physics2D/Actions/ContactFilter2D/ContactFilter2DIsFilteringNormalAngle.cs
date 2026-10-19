
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Checks if the angle of normal is within the normal angle range to be filtered.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.IsFilteringNormalAngle.h" +
		"tml")]
	public sealed class ContactFilter2DIsFilteringNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The normal used to calculate an angle.")]
		[SerializeField]
		private Vector2Var _normal;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _normal, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.IsFilteringNormalAngle(UnityEngine.Vector2);
			_result.Value = _contactFilter2D.Value.IsFilteringNormalAngle(_normal.Value);
		}
		
		public override string GetSummary()
		{
			return "Is Filtering Normal Angle {_contactFilter2D} {_normal} -> {_result}";
		}
	}
}
