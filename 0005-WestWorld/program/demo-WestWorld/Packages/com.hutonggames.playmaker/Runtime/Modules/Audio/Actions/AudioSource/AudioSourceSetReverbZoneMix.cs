
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The amount by which the signal from the AudioSource will be mixed into the global" +
		" reverb associated with the Reverb Zones.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-reverbZoneMix.html")]
	public sealed class AudioSourceSetReverbZoneMix : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Reverb Zone Mix")]
		[SerializeField]
		private FloatVar _setReverbZoneMix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setReverbZoneMix);
		}
		
		public override void Execute()
		{
			_audioSource.Value.reverbZoneMix = _setReverbZoneMix.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} reverb zone mix to {_setReverbZoneMix}";
		}
	}
}
