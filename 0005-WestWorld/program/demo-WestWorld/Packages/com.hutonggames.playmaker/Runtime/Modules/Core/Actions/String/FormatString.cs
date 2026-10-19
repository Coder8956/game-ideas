using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.String)]
	[ActionDescription("Creates a formatted string by replacing placeholders ({0}, {1}, etc.) with the specified string values.")]	
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting")]
	public sealed class FormatString : BaseAction
	{
		[Tooltip("The format string with numbered placeholders." +
		         "<br/>Examples:" +
		         "<br/>\"Hello {0}!\" -> \"Hello World!\"\n" +
		         "<br/>\"Player {0} scored {1} points\" -> \"Player John scored 100 points\"\n" +
		         "<br/>\"Position: {0},{1},{2}\" -> \"Position: 10,20,30\"")]		[SerializeField]
		private StringVar _format;
		
		[Tooltip("The Strings to use as parameters.")]
		[SerializeField]
		private StringVar[] _strings;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute() => CheckParameters(_format, _strings, _result);

		public override void Execute()
		{
			var args = new object[_strings.Length];
			for (int i = 0; i < _strings.Length; i++)
			{
				args[i] = _strings[i].Value;
			}

			_result.Value = string.Format(_format.Value, args);
		}
		
		public override string GetSummary()
		{
			return "Format {_format} with {_strings} -> {_result}";
		}
		
		#if UNITY_EDITOR

		public override string ErrorCheck()
		{
			if (string.IsNullOrEmpty(_format?.Value))
				return "Format string is empty";

			try
			{
				var text = _format.Value;
				var maxIndex = -1;
				var hasPlaceholders = false;

				// Single pass through the string
				for (int i = 0; i < text.Length - 1; i++)
				{
					if (text[i] == '{' && char.IsDigit(text[i + 1]))
					{
						hasPlaceholders = true;
						var num = 0;
						i++; // skip to first digit

						// Parse the number
						while (i < text.Length && char.IsDigit(text[i]))
						{
							num = num * 10 + (text[i] - '0');
							i++;
						}

						if (i < text.Length && text[i] == '}')
						{
							maxIndex = Math.Max(maxIndex, num);
						}
					}
				}

				if (!hasPlaceholders)
					return "Format string contains no placeholders";

				if (maxIndex >= _strings.Length)
					return
						$"Not enough parameters. Format string expects {maxIndex + 1} parameters but only {_strings.Length} provided";

				if (maxIndex < _strings.Length - 1)
					return
						$"Too many parameters. Format string expects {maxIndex + 1} parameters but {_strings.Length} provided";

				return string.Empty;
			}
			catch (ArgumentException)
			{
				return "Invalid format string";
			}
		}
		
		#endif
	}
}
