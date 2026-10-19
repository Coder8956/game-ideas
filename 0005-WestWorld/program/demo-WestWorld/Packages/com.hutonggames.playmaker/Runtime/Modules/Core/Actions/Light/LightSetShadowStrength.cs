
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("Strength of light\'s shadows.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-shadowStrength.html")]
	public sealed class LightSetShadowStrength : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Shadow Strength")]
		[SerializeField]
		[DefaultValue(1f)]
		private FloatVar _setShadowStrength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setShadowStrength);
		}
		
		public override void Execute()
		{
			_light.Value.shadowStrength = _setShadowStrength.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} shadow strength to {_setShadowStrength}";
		}
	}
}
