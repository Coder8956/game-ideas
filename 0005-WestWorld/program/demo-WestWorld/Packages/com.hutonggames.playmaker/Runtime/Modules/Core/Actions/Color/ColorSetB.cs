
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Blue component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-b.html")]
	public sealed class ColorSetB : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[VarSlider(0,1)]
		[Tooltip("Set Color B")]
		[SerializeField]
		private FloatVar _setB;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _setB);
		}
		
		public override void Execute()
		{
			var value = _color.Value;
			value.b = _setB.Value;
			_color.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color} B to {_setB}";
		}
	}
}
