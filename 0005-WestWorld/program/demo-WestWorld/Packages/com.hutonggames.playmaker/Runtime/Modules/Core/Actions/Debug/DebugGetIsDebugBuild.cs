
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("In the Build Settings dialog there is a check box called \"Development Build\".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug-isDebugBuild.html")]
	public sealed class DebugGetIsDebugBuild : BaseAction
	{
		
		[Tooltip("Get Debug Is Debug Build")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsDebugBuild;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getIsDebugBuild);
		}
		
		public override void Execute()
		{
			_getIsDebugBuild.Value = Debug.isDebugBuild;
		}
		
		public override string GetSummary()
		{
			return "Get Debug isDebugBuild -> {_getIsDebugBuild} ";
		}
	}
}
