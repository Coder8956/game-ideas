
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Sets the float value of the preference identified by the given key. " +
	                   "You can use PlayerPrefs.GetFloat to retrieve this value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.SetFloat.html")]
	public sealed class PlayerPrefsSetFloat : BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[Tooltip("Value to save in the PlayerPref.")]
		[SerializeField]
		private FloatVar _value;
		
		public override bool CanExecute() => CheckParameters(_key, _value);

		public override void Execute() => PlayerPrefs.SetFloat(_key.Value, _value.Value);

		public override string GetSummary() => "Set PlayerPref Float {_key} to {_value} ";
	}
}
