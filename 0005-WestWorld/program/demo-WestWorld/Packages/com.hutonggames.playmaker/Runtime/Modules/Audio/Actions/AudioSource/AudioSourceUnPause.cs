
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Unpause the paused playback of this AudioSource.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.UnPause.html")]
	public sealed class AudioSourceUnPause : BaseAction
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
			//UnityEngine.AudioSource.UnPause();
			_audioSource.Value.UnPause();
		}
		
		public override string GetSummary()
		{
			return "Unpause {_audioSource}";
		}
	}
}
