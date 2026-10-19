
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Turns off normal angle filtering by setting useNormalAngle to false. The associat" +
		"ed values of minNormalAngle and maxNormalAngle are not changed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.ClearNormalAngle.html")]
	public sealed class ContactFilter2DClearNormalAngle : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.ClearNormalAngle();
			_contactFilter2D.Value.ClearNormalAngle();
		}
		
		public override string GetSummary()
		{
			return "Clear Normal Angle {_contactFilter2D} ";
		}
	}
}
