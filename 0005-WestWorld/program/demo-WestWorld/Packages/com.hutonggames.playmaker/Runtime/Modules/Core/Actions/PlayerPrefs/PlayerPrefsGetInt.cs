
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Returns the value corresponding to key in the preference file if it exists.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.GetInt.html")]
	public sealed class PlayerPrefsGetInt : BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[OptionalField]
		[Tooltip("Default value to use if the key cannot be found.")]
		[SerializeField]
		private IntegerVar _defaultValue;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute() => CheckParameters(_key, _result);

		public override void Execute() => _result.Value = PlayerPrefs.GetInt(_key.Value, _defaultValue.Value);

		public override string GetSummary() => "Get PlayerPref Int: {_key} -> {_result} " +
		                                       (_defaultValue.IsNotDefault() ? "(default: {_defaultValue})" : "");
	}
}
