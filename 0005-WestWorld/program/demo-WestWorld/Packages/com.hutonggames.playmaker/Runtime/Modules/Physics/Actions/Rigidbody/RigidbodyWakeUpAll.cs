
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Forces all rigidbodies to wake up.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.WakeUp.html")]
	public sealed class RigidbodyWakeUpAll : BaseAction
	{
		public override void Execute()
		{
			var rigidbodies = Internal.CompatibilityShims.FindObjectsByTypeShim<Rigidbody>();
			foreach (var rb in rigidbodies)
			{
				if (rb != null) 
					rb.WakeUp();
			}
		}
		
		public override string GetSummary() => "Wake up all rigidbodies";
	}
}
