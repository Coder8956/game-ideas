
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Pauses playing the clip.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.Pause.html")]
	public sealed class AudioSourcePause : BaseAction
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
			//UnityEngine.AudioSource.Pause();
			_audioSource.Value.Pause();
		}
		
		public override string GetSummary()
		{
			return "Pause {_audioSource}";
		}
	}
}
