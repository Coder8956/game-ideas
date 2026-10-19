
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The angle of the spot light\'s cone in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-spotAngle.html")]
	public sealed class LightSetSpotAngle : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Spot Angle")]
		[SerializeField]
		[DefaultValue(30f)]
		private FloatVar _setSpotAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setSpotAngle);
		}
		
		public override void Execute()
		{
			_light.Value.spotAngle = _setSpotAngle.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} spot angle to {_setSpotAngle}";
		}
	}
}
