
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.TMP_Text)]
	[ConvertibleGroup("SetText")]
	[ActionDescription("Set the text using an Integer variable with optional formatting.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetText__Integer : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Text")]
		[SerializeField, CanBeNullOrEmpty]
		private IntegerVar _integer;
		
		[Tooltip("Format string. Composite example: 'Level: {0}' or '{0:D5}'. Value format example: 'D5'.\n" +
		         "Common examples:\n" +
		         "\"D5\" -> Decimal with 5 digits (e.g., 00123)\n" +
		         "\"N0\" -> Number with commas (e.g., 1,234)\n" +
		         "\"C\" -> Currency (e.g., $123)\n" +
		         "Leave empty for default format")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _integer);
		}
		
		public override void Execute()
		{
			var format = _format.Value;
			if (string.IsNullOrEmpty(format))
			{
				_tMP_Text.Value.text = _integer.Value.ToString();
				return;
			}
			
			try
			{
				_tMP_Text.Value.text = format.Contains("{0")
					? string.Format(format, _integer.Value)
					: _integer.Value.ToString(format);
			}
			catch (FormatException)
			{
				_tMP_Text.Value.text = _integer.Value.ToString();
			}
		}
		
		public override string GetSummary() =>
			_format.IsNotDefault()
				? "Set {_tMP_Text} Text to {_integer} ({_format})"
				: "Set {_tMP_Text} Text to {_integer}";
	}
}
