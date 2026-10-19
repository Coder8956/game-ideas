
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Indicates the current brightness of the screen.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-brightness.html")]
	public sealed class ScreenGetBrightness : BaseAction
	{
		
		[Tooltip("Get Screen Brightness")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBrightness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getBrightness);
		}
		
		public override void Execute()
		{
			_getBrightness.Value = Screen.brightness;
		}
		
		public override string GetSummary()
		{
			return "Get screen brightness -> {_getBrightness}";
		}
	}
}
