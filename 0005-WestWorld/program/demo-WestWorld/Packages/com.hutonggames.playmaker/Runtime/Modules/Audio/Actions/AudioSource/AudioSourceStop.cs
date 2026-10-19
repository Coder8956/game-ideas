
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Stops playing the clip.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.Stop.html")]
	public sealed class AudioSourceStop : BaseAction
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
			//UnityEngine.AudioSource.Stop();
			_audioSource.Value.Stop();
		}
		
		public override string GetSummary()
		{
			return "Stop {_audioSource}";
		}
	}
}
