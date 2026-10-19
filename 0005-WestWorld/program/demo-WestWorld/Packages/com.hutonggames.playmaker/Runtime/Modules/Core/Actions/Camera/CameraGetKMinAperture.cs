
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The minimum allowed aperture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-kMinAperture.html")]
	public sealed class CameraGetKMinAperture : BaseAction
	{
		
		[Tooltip("Get Camera Min Aperture")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKMinAperture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKMinAperture);
		}
		
		public override void Execute()
		{
			_getKMinAperture.Value = Camera.kMinAperture;
		}
		
		public override string GetSummary()
		{
			return "Get Camera min aperture -> {_getKMinAperture}";
		}
	}
}
