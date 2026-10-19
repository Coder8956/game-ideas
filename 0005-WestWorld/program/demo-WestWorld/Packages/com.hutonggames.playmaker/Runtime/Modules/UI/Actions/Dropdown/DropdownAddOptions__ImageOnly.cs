
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("Add multiple image-only options to the options of the Dropdown based on a list of Sprites.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownAddOptions__ImageOnly : BaseAction
	{
		
		[Tooltip("The Dropdown.")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Options.")]
		[SerializeField]
		private SpriteListVar _options;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _options);
		}
		
		public override void Execute()
		{
			_dropdown.Value.AddOptions(_options.Value);
		}
		
		public override string GetSummary()
		{
			return "{_dropdown} Add Options {_options} ";
		}
	}
}
