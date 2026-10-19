
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Un- / Mutes the AudioSource. Mute sets the volume=0, Un-Mute restore the original" +
		" volume.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-mute.html")]
	public sealed class AudioSourceSetMute : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Mute")]
		[SerializeField]
		private BoolVar _setMute;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setMute);
		}
		
		public override void Execute()
		{
			_audioSource.Value.mute = _setMute.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} mute to {_setMute}";
		}
	}
}
