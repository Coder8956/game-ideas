
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayerPrefs)]
	[ActionDescription("Returns true if the given key exists in PlayerPrefs, otherwise returns false.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PlayerPrefs.HasKey.html")]
	public sealed class PlayerPrefsHasKey : BaseTrueFalseAction
	{
		
		[Tooltip("A unique name used to identify the saved data.")]
		[SerializeField]
		private StringVar _key;
		
		public override bool CanExecute() => CheckParameters(_key);

		protected override bool Test() => PlayerPrefs.HasKey(_key.Value);

		protected override string TrueSummary => "PlayerPrefs Has Key {_key}";
		protected override string FalseSummary => "PlayerPrefs does not have key {_key}";
	}
}
