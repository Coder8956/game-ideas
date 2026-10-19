
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Given viewport coordinates, calculates the view space vectors pointing to the " +
	                   "four frustum corners at the specified camera depth." +
	                   "\n\nThis can be used to efficiently calculate the world space position of a pixel in an " +
	                   "image effect shader. See standard assets implementation of global fog.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.CalculateFrustumCorners.html")]
	public sealed class CameraCalculateFrustumCorners : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField, DefaultValue("~MainCamera")]
		private CameraVar _camera;
		
		[Tooltip("Normalized viewport coordinates to use for the frustum calculation.")]
		[SerializeField, DefaultValue("Rect.one")]
		private RectVar _viewport;
		
		[Tooltip("Z-depth from the camera origin at which the corners will be calculated.")]
		[SerializeField, DefaultValue(100f)]
		private FloatVar _zDepth;
		
		[Tooltip("Camera eye projection matrix to use.")]
		[SerializeField, DefaultValue("Mono")]
		private Camera_MonoOrStereoscopicEyeVar _eye;
		
		[Tooltip("Output array for the frustum corner vectors. Cannot be null and length must be >= 4.")]
		[SerializeField, WriteOnly]
		private Vector3ListRef _outCorners;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _viewport, _zDepth, _eye, _outCorners);
		}
		
		public override void Execute()
		{
			if (_outCorners.Length < 4)
			{
				_outCorners.Value = new List<Vector3>( new Vector3[4]);
			}
			_camera.Value.CalculateFrustumCorners(_viewport.Value, _zDepth.Value, _eye.Value, _outCorners.Values);
		}
		
		public override string GetSummary()
		{
			return "Calculate {_camera} frustum corners -> {_outCorners}";
		}
	}
}
