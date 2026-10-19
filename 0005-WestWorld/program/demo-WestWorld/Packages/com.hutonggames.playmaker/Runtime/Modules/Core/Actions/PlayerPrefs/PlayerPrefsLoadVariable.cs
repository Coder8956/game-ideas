
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[Tooltip("Load a variable value saved with PlayerPrefs Save Variable. " +
	         "The Key should be a unique identifier for the variable." +
	         "<br/>NOTE: You cannot save references to Scene Objects in PlayerPrefs!")]
	public sealed class PlayerPrefsLoadVariable: BaseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		[Tooltip("Variable to load.<br/>NOTE: The variable should be of the same type as the saved variable.")]
		[SerializeReference, WriteOnly]
		private AnyVariableRef _variable;
		
		public override bool CanExecute() => !_variable.IsNone && CheckParameters(_key);

		public override void Execute()
		{
			var json = PlayerPrefs.GetString(_key.Value, "");
			var value = JsonUtility.FromJson(json, _variable.DataType);
			_variable.SetValue(value);
		}

		public override string GetSummary() => "Load {_variable} from PlayerPrefs {_key}";
	}
}
