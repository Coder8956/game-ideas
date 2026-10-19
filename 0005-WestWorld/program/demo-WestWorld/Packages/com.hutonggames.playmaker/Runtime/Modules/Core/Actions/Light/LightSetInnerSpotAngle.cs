
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The angle of the spot light\'s inner cone in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-innerSpotAngle.html")]
	public sealed class LightSetInnerSpotAngle : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Inner Spot Angle")]
		[SerializeField]
		private FloatVar _setInnerSpotAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setInnerSpotAngle);
		}
		
		public override void Execute()
		{
			_light.Value.innerSpotAngle = _setInnerSpotAngle.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} inner spot angle to {_setInnerSpotAngle}";
		}
	}
}
