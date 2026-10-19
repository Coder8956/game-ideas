
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Allows AudioSource to play even though AudioListener.pause is set to true. This i" +
		"s useful for the menu element sounds or background music in pause menus.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerPause.html")]
	public sealed class AudioSourceSetIgnoreListenerPause : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Ignore Listener Pause")]
		[SerializeField]
		private BoolVar _setIgnoreListenerPause;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setIgnoreListenerPause);
		}
		
		public override void Execute()
		{
			_audioSource.Value.ignoreListenerPause = _setIgnoreListenerPause.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} ignore listener pause to {_setIgnoreListenerPause}";
		}
	}
}
