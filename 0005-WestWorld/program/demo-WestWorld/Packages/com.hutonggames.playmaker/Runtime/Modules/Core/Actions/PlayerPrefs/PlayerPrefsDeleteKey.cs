
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Removes the given key from the PlayerPrefs. " +
	                   "If the key does not exist, DeleteKey has no impact.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.DeleteKey.html")]
	public sealed class PlayerPrefsDeleteKey : BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		public override bool CanExecute() => CheckParameters(_key);

		public override void Execute() => PlayerPrefs.DeleteKey(_key.Value);

		public override string GetSummary() => "Delete PlayerPref: {_key} ";
	}
}
