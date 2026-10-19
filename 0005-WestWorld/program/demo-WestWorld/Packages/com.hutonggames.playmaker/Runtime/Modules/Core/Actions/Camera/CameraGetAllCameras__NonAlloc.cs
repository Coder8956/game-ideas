
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Fills an array of Camera with the current cameras in the Scene, without allocating a new array.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.GetAllCameras.html")]
	public sealed class CameraGetAllCameras__NonAlloc : BaseAction
	{
		
		[Tooltip("An array to be filled up with cameras currently in the Scene.")]
		[SerializeField]
		private CameraListRef _cameras;

		private Camera[] _cameraBuffer;
		
		[Tooltip("Store the number of cameras found in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _numCameras;
		
		public override bool CanExecute()
		{
			return CheckParameters(_cameras, _numCameras);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.GetAllCameras(UnityEngine.Camera[]);
			if (!_cameras.TryGetNonAllocBuffer(ref _cameraBuffer))
			{
				return;
			}

			_numCameras.Value = Camera.GetAllCameras(_cameraBuffer);
			_cameras.CopyFromNonAllocBuffer(_cameraBuffer);
		}
		
		public override string GetSummary()
		{
			return "Get all cameras into {_cameras} ({_numCameras})";
		}
	}
}
