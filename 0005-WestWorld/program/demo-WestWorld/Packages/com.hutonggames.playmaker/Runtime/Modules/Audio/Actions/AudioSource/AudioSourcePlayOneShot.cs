
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays an AudioClip.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayOneShot.html")]
	public sealed class AudioSourcePlayOneShot : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("The clip being played.")]
		[SerializeField]
		private AudioClipVar _clip;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _clip);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.PlayOneShot(UnityEngine.AudioClip);
			_audioSource.Value.PlayOneShot(_clip.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_clip} on {_audioSource}";
		}
	}
}
