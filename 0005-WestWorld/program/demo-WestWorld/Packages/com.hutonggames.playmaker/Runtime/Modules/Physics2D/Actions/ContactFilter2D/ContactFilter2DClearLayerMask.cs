
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Turns off layer mask filtering by setting useLayerMask to false. The associated v" +
		"alue of layerMask is not changed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.ClearLayerMask.html")]
	public sealed class ContactFilter2DClearLayerMask : BaseAction
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
			//UnityEngine.ContactFilter2D.ClearLayerMask();
			_contactFilter2D.Value.ClearLayerMask();
		}
		
		public override string GetSummary()
		{
			return "Clear Layer Mask {_contactFilter2D} ";
		}
	}
}
