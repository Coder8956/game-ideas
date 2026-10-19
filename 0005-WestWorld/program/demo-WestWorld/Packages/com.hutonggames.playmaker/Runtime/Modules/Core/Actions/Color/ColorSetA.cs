
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Alpha component of the color (0 is transparent, 1 is opaque).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-a.html")]
	public sealed class ColorSetA : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[VarSlider(0,1)]
		[Tooltip("Set Color A")]
		[SerializeField]
		private FloatVar _setA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _setA);
		}
		
		public override void Execute()
		{
			var value = _color.Value;
			value.a = _setA.Value;
			_color.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color} A to {_setA}";
		}
	}
}
