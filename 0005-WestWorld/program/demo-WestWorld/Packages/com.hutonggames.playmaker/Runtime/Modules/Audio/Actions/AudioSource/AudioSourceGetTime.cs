
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
	public sealed class AudioSourceGetTime : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Get AudioSource Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _getTime);
		}
		
		public override void Execute()
		{
			_getTime.Value = _audioSource.Value.time;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioSource} time -> {_getTime}";
		}
	}
}
