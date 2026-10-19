
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The first enabled Camera component that is tagged \"MainCamera\" (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-main.html")]
	public sealed class CameraGetMain : BaseAction
	{
		
		[Tooltip("Get Camera Main")]
		[SerializeField]
		[WriteOnly]
		private CameraVar _getMain;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMain);
		}
		
		public override void Execute()
		{
			_getMain.Value = Camera.main;
		}
		
		public override string GetSummary()
		{
			return "Get Camera main -> {_getMain}";
		}
	}
}
