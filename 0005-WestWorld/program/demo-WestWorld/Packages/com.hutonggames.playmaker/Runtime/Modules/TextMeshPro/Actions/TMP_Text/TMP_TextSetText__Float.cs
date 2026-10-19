
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	[Serializable]
	[ActionCategory(Category.TMP_Text)]
	[ConvertibleGroup("SetText")]
	[ActionDescription("Set the text using a Float variable with optional formatting.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetText__Float : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Text")]
		[SerializeField, CanBeNullOrEmpty]
		private FloatVar _float;
		
		[Tooltip("Format string. Composite example: 'Level: {0}' or '{0:F2}'. Value format example: 'F2'.\n" +
		         "Common examples:\n" +
		         "\"F2\" -> Fixed-point, 2 decimals (e.g., 123.46)\n" +
		         "\"N1\" -> Number with commas, 1 decimal (e.g., 1,234.5)\n" +
		         "\"E2\" -> Scientific, 2 decimals (e.g., 1.23E+003)\n" +
		         "\"P0\" -> Percentage, no decimals (e.g., 12%)")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _float);
		}
		
		public override void Execute()
		{
			var format = _format.Value;
			if (string.IsNullOrEmpty(format))
			{
				_tMP_Text.Value.text = _float.Value.ToString();
				return;
			}
			
			try
			{
				_tMP_Text.Value.text = format.Contains("{0")
					? string.Format(format, _float.Value)
					: _float.Value.ToString(format);
			}
			catch (FormatException)
			{
				_tMP_Text.Value.text = _float.Value.ToString();
			}
		}
		
		public override string GetSummary() =>
			_format.IsNotDefault()
				? "Set {_tMP_Text} Text to {_float} ({_format})"
				: "Set {_tMP_Text} Text to {_float}";
	}
}
