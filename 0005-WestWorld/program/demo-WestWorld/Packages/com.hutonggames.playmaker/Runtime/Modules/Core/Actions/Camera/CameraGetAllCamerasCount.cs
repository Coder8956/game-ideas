
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The number of cameras in the current Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allCamerasCount.html")]
	public sealed class CameraGetAllCamerasCount : BaseAction
	{
		
		[Tooltip("Get Camera All Cameras Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAllCamerasCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllCamerasCount);
		}
		
		public override void Execute()
		{
			_getAllCamerasCount.Value = Camera.allCamerasCount;
		}
		
		public override string GetSummary()
		{
			return "Get Camera all cameras count -> {_getAllCamerasCount}";
		}
	}
}
