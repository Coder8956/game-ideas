
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Determines whether the stereo view matrices are suitable to allow for a single pa" +
		"ss cull.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-areVRStereoViewMatricesWithinSing" +
		"leCullTolerance.html")]
	public sealed class CameraGetAreVRStereoViewMatricesWithinSingleCullTolerance : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Are VR Stereo View Matrices Within float Cull Tolerance")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAreVRStereoViewMatricesWithinSingleCullTolerance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAreVRStereoViewMatricesWithinSingleCullTolerance);
		}
		
		public override void Execute()
		{
			_getAreVRStereoViewMatricesWithinSingleCullTolerance.Value = _camera.Value.areVRStereoViewMatricesWithinSingleCullTolerance;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} VR stereo view matrices within single cull tolerance -> {_getAreVRStereoViewMatricesWithinSingleCullTolerance}";
		}
	}
}
