/* Deprecated
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Plays the clip.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.Play.html")]
	public sealed class AudioSourcePlay1 : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AudioSourceVar _audioSource;
		
		[Tooltip("Deprecated. Delay in number of samples, assuming a 44100Hz sample rate (meaning t" +
			"hat Play(44100) will delay the playing by exactly 1 sec).")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UInt64Var _delay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _delay);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.Play(System.UInt64);
			_audioSource.Value.Play(_delay.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_audioSource} after {_delay}";
		}
	}
}
*/
