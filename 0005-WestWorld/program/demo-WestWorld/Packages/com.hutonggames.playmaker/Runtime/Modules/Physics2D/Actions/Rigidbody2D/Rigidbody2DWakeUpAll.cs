
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Disables the \"sleeping\" state of all 2D rigidbodies.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.WakeUp.html")]
	public sealed class Rigidbody2DWakeUpAll : BaseAction
	{
		public override void Execute()
		{
			var rigidbodies = Internal.CompatibilityShims.FindObjectsByTypeShim<Rigidbody2D>();
			foreach (var rb in rigidbodies)
			{
				if (rb != null) 
					rb.WakeUp();
			}
		}
		
		public override string GetSummary() => "Wake up all 2D rigidbodies";
	}
}
