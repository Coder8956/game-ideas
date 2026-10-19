
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Light)]
	[ActionDescription("The flare asset to use for this light.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Light-flare.html")]
	public sealed class LightSetFlare : BaseAction
	{
		
		[Tooltip("The Light")]
		[SerializeField]
		private LightVar _light;
		
		[Tooltip("Set Light Flare")]
		[SerializeField, CanBeNullOrEmpty]
		private FlareVar _setFlare;
		
		public override bool CanExecute()
		{
			return CheckParameters(_light);
		}
		
		public override void Execute()
		{
			_light.Value.flare = _setFlare.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_light} flare to {_setFlare}";
		}
	}
}
