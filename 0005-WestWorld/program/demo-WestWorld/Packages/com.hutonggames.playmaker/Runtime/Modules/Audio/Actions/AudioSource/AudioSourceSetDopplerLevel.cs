
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets the Doppler scale for this AudioSource.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-dopplerLevel.html")]
	public sealed class AudioSourceSetDopplerLevel : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Doppler Level")]
		[SerializeField]
		private FloatVar _setDopplerLevel;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setDopplerLevel);
		}
		
		public override void Execute()
		{
			_audioSource.Value.dopplerLevel = _setDopplerLevel.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} doppler level to {_setDopplerLevel}";
		}
	}
}
