
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Pans a playing sound in a stereo way (left or right). This only applies to sounds" +
		" that are Mono or Stereo.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-panStereo.html")]
	public sealed class AudioSourceSetPanStereo : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Pan Stereo")]
		[SerializeField]
		private FloatVar _setPanStereo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setPanStereo);
		}
		
		public override void Execute()
		{
			_audioSource.Value.panStereo = _setPanStereo.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} pan stereo to {_setPanStereo}";
		}
	}
}
