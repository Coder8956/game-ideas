
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Sets a single string value for the preference identified by the given key. " +
	                   "You can use PlayerPrefs.GetString to retrieve this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.SetString.html")]
	public sealed class PlayerPrefsSetString : BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[Tooltip("Value to save in the PlayerPref.")]
		[SerializeField]
		private StringVar _value;
		
		public override bool CanExecute() => CheckParameters(_key, _value);

		public override void Execute() => PlayerPrefs.SetString(_key.Value, _value.Value);

		public override string GetSummary() => "Set PlayerPref String {_key} to {_value} ";
	}
}
