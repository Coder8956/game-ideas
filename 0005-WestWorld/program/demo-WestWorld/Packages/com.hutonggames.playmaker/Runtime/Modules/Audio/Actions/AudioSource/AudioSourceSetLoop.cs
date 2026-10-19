
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Is the audio clip looping?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-loop.html")]
	public sealed class AudioSourceSetLoop : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Loop")]
		[SerializeField]
		private BoolVar _setLoop;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setLoop);
		}
		
		public override void Execute()
		{
			_audioSource.Value.loop = _setLoop.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} loop to {_setLoop}";
		}
	}
}
