
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("Add options to the Dropdown.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownAddOptions__Strings : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown.")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Options.")]
		[SerializeField]
		private StringListVar _options;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _options);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Dropdown.AddOptions(System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]);
			_tMP_Dropdown.Value.AddOptions(_options.Value);
		}
		
		public override string GetSummary()
		{
			return "Add options {_options} to {_tMP_Dropdown}";
		}
	}
}
