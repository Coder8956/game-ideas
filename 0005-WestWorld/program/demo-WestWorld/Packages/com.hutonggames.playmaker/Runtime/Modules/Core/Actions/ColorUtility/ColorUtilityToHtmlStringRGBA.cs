
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ColorUtility)]
	[ActionDescription("Returns the color as a hexadecimal string in the format \"RRGGBBAA\".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ColorUtility.ToHtmlStringRGBA.html")]
	public sealed class ColorUtilityToHtmlStringRGBA : BaseAction
	{
		
		[Tooltip("The color to be converted.")]
		[SerializeField]
		private ColorVar _color;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ColorUtility.ToHtmlStringRGBA(UnityEngine.Color);
			_result.Value = ColorUtility.ToHtmlStringRGBA(_color.Value);
		}
		
		public override string GetSummary()
		{
			return "ColorUtility To Html String RGBA: {_color} -> {_result}";
		}
	}
}
