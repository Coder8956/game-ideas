
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The minimum blade count for the aperture diaphragm.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-kMinBladeCount.html")]
	public sealed class CameraGetKMinBladeCount : BaseAction
	{
		
		[Tooltip("Get Camera Min Blade Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getKMinBladeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKMinBladeCount);
		}
		
		public override void Execute()
		{
			_getKMinBladeCount.Value = Camera.kMinBladeCount;
		}
		
		public override string GetSummary()
		{
			return "Get Camera min blade count -> {_getKMinBladeCount}";
		}
	}
}
