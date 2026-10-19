
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The range of the light.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-range.html")]
	public sealed class LightSetRange : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Range")]
		[SerializeField]
		[DefaultValue(10f)]
		private FloatVar _setRange;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setRange);
		}
		
		public override void Execute()
		{
			_light.Value.range = _setRange.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} range to {_setRange}";
		}
	}
}
