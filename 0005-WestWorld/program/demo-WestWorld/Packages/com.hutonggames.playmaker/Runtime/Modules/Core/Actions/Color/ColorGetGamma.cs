
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("A version of the color that has had the gamma curve applied.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-gamma.html")]
	public sealed class ColorGetGamma : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color Gamma")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getGamma;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getGamma);
		}
		
		public override void Execute()
		{
			_getGamma.Value = _color.Value.gamma;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} Gamma -> {_getGamma}";
		}
	}
}
