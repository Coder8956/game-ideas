using System;

namespace HutongGames.PlayMaker.Actions
{
	internal static class StringSplitOptionsUtility
	{
		private static readonly StringSplitOptions ValidOptions = GetValidOptions();

		public static StringSplitOptions GetRuntimeOptions(StringSplitOptions options)
		{
			return options & ValidOptions;
		}

		private static StringSplitOptions GetValidOptions()
		{
			var options = StringSplitOptions.None;
			foreach (StringSplitOptions value in Enum.GetValues(typeof(StringSplitOptions)))
			{
				if ((int)value >= 0)
				{
					options |= value;
				}
			}

			return options;
		}
	}
}
