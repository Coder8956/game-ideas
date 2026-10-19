/* Internal?
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Performs Camera Setup Current.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.SetupCurrent.html")]
	public sealed class CameraSetupCurrent : BaseAction
	{
		
		[Tooltip("Cur.")]
		[SerializeField]
		private CameraVar _cur;
		
		public override bool CanExecute()
		{
			return CheckParameters(_cur);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.SetupCurrent(UnityEngine.Camera);
			Camera.SetupCurrent(_cur.Value);
		}
		
		public override string GetSummary()
		{
			return "Set up Camera current {_cur}";
		}
	}
}
*/
