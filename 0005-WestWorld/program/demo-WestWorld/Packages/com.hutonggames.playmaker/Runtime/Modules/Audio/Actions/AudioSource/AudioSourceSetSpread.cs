
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets the spread angle (in degrees) of a 3d stereo or multichannel sound in speake" +
		"r space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-spread.html")]
	public sealed class AudioSourceSetSpread : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Spread")]
		[SerializeField]
		private FloatVar _setSpread;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setSpread);
		}
		
		public override void Execute()
		{
			_audioSource.Value.spread = _setSpread.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} spread to {_setSpread}";
		}
	}
}
