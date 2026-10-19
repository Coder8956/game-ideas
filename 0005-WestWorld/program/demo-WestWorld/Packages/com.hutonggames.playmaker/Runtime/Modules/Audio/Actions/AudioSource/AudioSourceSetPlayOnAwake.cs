
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("If set to true, the audio source will automatically start playing on awake.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-playOnAwake.html")]
	public sealed class AudioSourceSetPlayOnAwake : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Play On Awake")]
		[SerializeField]
		private BoolVar _setPlayOnAwake;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setPlayOnAwake);
		}
		
		public override void Execute()
		{
			_audioSource.Value.playOnAwake = _setPlayOnAwake.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} play on awake to {_setPlayOnAwake}";
		}
	}
}
