
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("A linear value of an sRGB color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-linear.html")]
	public sealed class ColorGetLinear : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color Linear")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getLinear;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getLinear);
		}
		
		public override void Execute()
		{
			_getLinear.Value = _color.Value.linear;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} Linear -> {_getLinear}";
		}
	}
}
