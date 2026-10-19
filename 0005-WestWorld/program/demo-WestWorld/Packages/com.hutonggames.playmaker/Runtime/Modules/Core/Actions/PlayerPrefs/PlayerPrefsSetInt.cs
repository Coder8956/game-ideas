
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Sets a single integer value for the preference identified by the given key. " +
	                   "You can use PlayerPrefs.GetInt to retrieve this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.SetInt.html")]
	public sealed class PlayerPrefsSetInt : BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[Tooltip("Value to save in the PlayerPref.")]
		[SerializeField]
		private IntegerVar _value;
		
		public override bool CanExecute() => CheckParameters(_key, _value);

		public override void Execute() => PlayerPrefs.SetInt(_key.Value, _value.Value);

		public override string GetSummary() => "Set PlayerPref Int {_key} to {_value} ";
	}
}
