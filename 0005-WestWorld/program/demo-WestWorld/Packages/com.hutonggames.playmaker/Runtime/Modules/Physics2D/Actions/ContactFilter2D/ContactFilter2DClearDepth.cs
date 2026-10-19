
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Turns off depth filtering by setting useDepth to false. The associated values of " +
		"minDepth and maxDepth are not changed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.ClearDepth.html")]
	public sealed class ContactFilter2DClearDepth : BaseAction
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
			//UnityEngine.ContactFilter2D.ClearDepth();
			_contactFilter2D.Value.ClearDepth();
		}
		
		public override string GetSummary()
		{
			return "Clear Depth {_contactFilter2D} ";
		}
	}
}
