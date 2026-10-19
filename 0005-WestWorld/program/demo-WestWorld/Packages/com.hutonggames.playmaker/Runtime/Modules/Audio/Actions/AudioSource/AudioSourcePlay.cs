
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays the clip.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.Play.html")]
	public sealed class AudioSourcePlay : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.Play();
			_audioSource.Value.Play();
		}
		
		public override string GetSummary()
		{
			return "Play {_audioSource}";
		}
	}
}
