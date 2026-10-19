
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("When set doesn\'t route the signal from an AudioSource into the global reverb asso" +
		"ciated with reverb zones.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-bypassReverbZones.html")]
	public sealed class AudioSourceSetBypassReverbZones : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Bypass Reverb Zones")]
		[SerializeField]
		private BoolVar _setBypassReverbZones;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setBypassReverbZones);
		}
		
		public override void Execute()
		{
			_audioSource.Value.bypassReverbZones = _setBypassReverbZones.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} bypass reverb zones to {_setBypassReverbZones}";
		}
	}
}
