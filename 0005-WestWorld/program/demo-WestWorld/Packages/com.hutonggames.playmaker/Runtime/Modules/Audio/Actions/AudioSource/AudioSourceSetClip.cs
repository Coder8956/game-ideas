
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The default AudioClip to play.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-clip.html")]
	public sealed class AudioSourceSetClip : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Clip")]
		[SerializeField, CanBeNullOrEmpty]
		private AudioClipVar _setClip;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource);
		}
		
		public override void Execute()
		{
			_audioSource.Value.clip = _setClip.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} clip to {_setClip}";
		}
	}
}
