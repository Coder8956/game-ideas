
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets how much this AudioSource is affected by 3D spatialisation calculations (att" +
		"enuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-spatialBlend.html")]
	public sealed class AudioSourceSetSpatialBlend : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Spatial Blend")]
		[SerializeField]
		private FloatVar _setSpatialBlend;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setSpatialBlend);
		}
		
		public override void Execute()
		{
			_audioSource.Value.spatialBlend = _setSpatialBlend.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} spatial blend to {_setSpatialBlend}";
		}
	}
}
