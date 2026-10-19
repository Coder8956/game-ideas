
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The color of the light.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-color.html")]
	public sealed class LightSetColor : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Color")]
		[SerializeField]
		[DefaultValue("Color.white")]
		private ColorVar _setColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setColor);
		}
		
		public override void Execute()
		{
			_light.Value.color = _setColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} color to {_setColor}";
		}
	}
}
