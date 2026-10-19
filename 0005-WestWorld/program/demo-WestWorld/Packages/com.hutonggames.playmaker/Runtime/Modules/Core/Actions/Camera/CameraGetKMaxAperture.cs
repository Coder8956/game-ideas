
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The maximum allowed aperture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-kMaxAperture.html")]
	public sealed class CameraGetKMaxAperture : BaseAction
	{
		
		[Tooltip("Get Camera Max Aperture")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKMaxAperture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKMaxAperture);
		}
		
		public override void Execute()
		{
			_getKMaxAperture.Value = Camera.kMaxAperture;
		}
		
		public override string GetSummary()
		{
			return "Get Camera max aperture -> {_getKMaxAperture}";
		}
	}
}
