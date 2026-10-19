
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("How this light casts shadows")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-shadows.html")]
	public sealed class LightSetShadows : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Shadows")]
		[SerializeField]
		private LightShadowsVar _setShadows;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light, _setShadows);
		}
		
		public override void Execute()
		{
			_light.Value.shadows = _setShadows.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} shadows to {_setShadows}";
		}
	}
}
