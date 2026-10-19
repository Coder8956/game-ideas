
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Converts the vertical field of view (FOV) to the horizontal FOV, based on the val" +
		"ue of the aspect ratio parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.VerticalToHorizontalFieldOfView.h" +
		"tml")]
	public sealed class CameraVerticalToHorizontalFieldOfView : BaseAction
	{
		
		[Tooltip("The vertical FOV value in degrees.")]
		[SerializeField]
		private FloatVar _verticalFieldOfView;
		
		[Tooltip("The aspect ratio value used for the conversion")]
		[SerializeField]
		private FloatVar _aspectRatio;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_verticalFieldOfView, _aspectRatio, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.VerticalToHorizontalFieldOfView(System.Single, System.Single);
			_result.Value = Camera.VerticalToHorizontalFieldOfView(_verticalFieldOfView.Value, _aspectRatio.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert vertical FOV {_verticalFieldOfView} and aspect ratio {_aspectRatio} to horizontal FOV -> {_result}";
		}
	}
}
