
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Pauses the editor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.Break.html")]
	public sealed class DebugBreak : BaseAction
	{
		public override void Execute()
		{
			//UnityEngine.Debug.Break();
			Debug.Break();
		}
	}
}
