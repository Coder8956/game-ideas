
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[Tooltip("Save a variable value in PlayerPrefs. " +
	         "You can load the value later with PlayerPrefs Load Variable." +
	         "<br/>NOTE: You cannot save references to Scene Objects in PlayerPrefs!")]
	public sealed class PlayerPrefsSaveVariable: BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[Tooltip("Variable to save in the PlayerPref.")]
		[SerializeReference]
		private AnyVariableRef _variable;
		
		public override bool CanExecute() => CheckParameters(_key, _variable);

		public override void Execute() => PlayerPrefs.SetString(_key.Value, JsonUtility.ToJson(_variable.GetValue()));

		public override string GetSummary() => "Save {_variable} in PlayerPrefs {_key}";
	}
}
