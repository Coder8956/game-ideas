
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Saves all modified preferences.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.Save.html")]
	public sealed class PlayerPrefsSave : BaseAction
	{
		public override void Execute() => PlayerPrefs.Save();

		public override string GetSummary() => "Save PlayerPrefs";
	}
}
