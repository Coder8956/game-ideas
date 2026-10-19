
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The camera we are currently rendering with, for low-level render control only (Re" +
		"ad Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-current.html")]
	public sealed class CameraGetCurrent : BaseAction
	{
		
		[Tooltip("Get Camera Current")]
		[SerializeField]
		[WriteOnly]
		private CameraVar _getCurrent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getCurrent);
		}
		
		public override void Execute()
		{
			_getCurrent.Value = Camera.current;
		}
		
		public override string GetSummary()
		{
			return "Get Camera current -> {_getCurrent}";
		}
	}
}
