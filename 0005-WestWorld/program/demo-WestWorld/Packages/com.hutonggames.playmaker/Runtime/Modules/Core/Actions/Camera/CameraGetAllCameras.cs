
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Returns all enabled cameras in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allCameras.html")]
	public sealed class CameraGetAllCameras : BaseAction
	{
		
		[Tooltip("Get Camera All Cameras")]
		[SerializeField]
		[WriteOnly]
		private CameraListRef _getAllCameras;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllCameras);
		}
		
		public override void Execute()
		{
			_getAllCameras.Values = Camera.allCameras;
		}
		
		public override string GetSummary()
		{
			return "Get Camera all cameras -> {_getAllCameras}";
		}
	}
}
