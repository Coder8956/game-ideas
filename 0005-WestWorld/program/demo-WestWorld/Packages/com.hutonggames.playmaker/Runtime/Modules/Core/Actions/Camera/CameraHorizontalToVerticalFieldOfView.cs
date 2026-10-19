
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Converts the horizontal field of view (FOV) to the vertical FOV, based on the val" +
		"ue of the aspect ratio parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.HorizontalToVerticalFieldOfView.h" +
		"tml")]
	public sealed class CameraHorizontalToVerticalFieldOfView : BaseAction
	{
		
		[Tooltip("Horizontal Field Of View.")]
		[SerializeField]
		private FloatVar _horizontalFieldOfView;
		
		[Tooltip("The aspect ratio value used for the conversion")]
		[SerializeField]
		private FloatVar _aspectRatio;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_horizontalFieldOfView, _aspectRatio, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.HorizontalToVerticalFieldOfView(System.Single, System.Single);
			_result.Value = Camera.HorizontalToVerticalFieldOfView(_horizontalFieldOfView.Value, _aspectRatio.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert horizontal FOV {_horizontalFieldOfView} and aspect ratio {_aspectRatio} to vertical FOV -> {_result}";
		}
	}
}
