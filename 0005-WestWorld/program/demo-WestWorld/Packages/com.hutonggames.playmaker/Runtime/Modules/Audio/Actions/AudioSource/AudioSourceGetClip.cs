
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The default AudioClip to play.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-clip.html")]
	public sealed class AudioSourceGetClip : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Get AudioSource Clip")]
		[SerializeField]
		[WriteOnly]
		private AudioClipRef _getClip;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _getClip);
		}
		
		public override void Execute()
		{
			_getClip.Value = _audioSource.Value.clip;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioSource} clip -> {_getClip}";
		}
	}
}
