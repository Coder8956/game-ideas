
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The volume of the audio source (0.0 to 1.0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-volume.html")]
	public sealed class AudioSourceGetVolume : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Get AudioSource Volume")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getVolume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _getVolume);
		}
		
		public override void Execute()
		{
			_getVolume.Value = _audioSource.Value.volume;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioSource} volume -> {_getVolume}";
		}
	}
}
