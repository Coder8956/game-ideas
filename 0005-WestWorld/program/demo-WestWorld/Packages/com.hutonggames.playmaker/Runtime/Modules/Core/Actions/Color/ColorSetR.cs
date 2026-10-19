
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Red component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-r.html")]
	public sealed class ColorSetR : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[VarSlider(0,1)]
		[Tooltip("Set Color R")]
		[SerializeField]
		private FloatVar _setR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _setR);
		}
		
		public override void Execute()
		{
			var value = _color.Value;
			value.r = _setR.Value;
			_color.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color} R to {_setR}";
		}
	}
}
