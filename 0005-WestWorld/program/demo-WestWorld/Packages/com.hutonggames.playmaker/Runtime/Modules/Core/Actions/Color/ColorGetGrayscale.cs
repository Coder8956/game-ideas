
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("The grayscale value of the color. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-grayscale.html")]
	public sealed class ColorGetGrayscale : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color Grayscale")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getGrayscale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getGrayscale);
		}
		
		public override void Execute()
		{
			_getGrayscale.Value = _color.Value.grayscale;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} Grayscale -> {_getGrayscale}";
		}
	}
}
