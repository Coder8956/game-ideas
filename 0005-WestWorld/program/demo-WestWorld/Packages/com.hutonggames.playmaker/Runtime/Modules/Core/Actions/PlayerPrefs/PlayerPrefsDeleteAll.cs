
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Removes all keys and values from the preferences. Use with caution.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.DeleteAll.html")]
	public sealed class PlayerPrefsDeleteAll : BaseAction
	{
		public override void Execute() => PlayerPrefs.DeleteAll();

		public override string GetSummary() => "Delete All PlayerPrefs";
	}
}
