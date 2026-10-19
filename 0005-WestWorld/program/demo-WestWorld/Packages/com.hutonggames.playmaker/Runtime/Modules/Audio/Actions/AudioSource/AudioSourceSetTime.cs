
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Playback position in seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-time.html")]
	public sealed class AudioSourceSetTime : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Time")]
		[SerializeField]
		private FloatVar _setTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setTime);
		}
		
		public override void Execute()
		{
			_audioSource.Value.time = _setTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} time to {_setTime}";
		}
	}
}
