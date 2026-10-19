
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The Intensity of a light is multiplied with the Light color." +
	                   "<br/>The value can be between 0 and 8. This allows you to create over bright lights.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-intensity.html")]
	public sealed class LightSetIntensity : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Intensity")]
		[SerializeField]
		[DefaultValue(1f)]
		private FloatVar _setIntensity;
		
		public override bool CanExecute() => CheckParameters(_light, _setIntensity);

		public override void Execute() => _light.Value.intensity = _setIntensity.Value;

		public override string GetSummary() => "Set {_light} Intensity to {_setIntensity}";
	}
}
