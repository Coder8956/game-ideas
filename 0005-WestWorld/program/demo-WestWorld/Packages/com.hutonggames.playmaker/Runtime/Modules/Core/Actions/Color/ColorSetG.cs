
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Green component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-g.html")]
	public sealed class ColorSetG : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[VarSlider(0,1)]
		[Tooltip("Set Color G")]
		[SerializeField]
		private FloatVar _setG;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _setG);
		}
		
		public override void Execute()
		{
			var value = _color.Value;
			value.g = _setG.Value;
			_color.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color} G to {_setG}";
		}
	}
}
