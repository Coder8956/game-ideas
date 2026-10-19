
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The maximum blade count for the aperture diaphragm.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-kMaxBladeCount.html")]
	public sealed class CameraGetKMaxBladeCount : BaseAction
	{
		
		[Tooltip("Get Camera Max Blade Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getKMaxBladeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKMaxBladeCount);
		}
		
		public override void Execute()
		{
			_getKMaxBladeCount.Value = Camera.kMaxBladeCount;
		}
		
		public override string GetSummary()
		{
			return "Get Camera max blade count -> {_getKMaxBladeCount}";
		}
	}
}
