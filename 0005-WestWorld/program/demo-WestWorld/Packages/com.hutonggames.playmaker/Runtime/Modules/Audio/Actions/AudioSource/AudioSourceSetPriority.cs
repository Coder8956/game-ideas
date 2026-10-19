
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets the priority of the AudioSource.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-priority.html")]
	public sealed class AudioSourceSetPriority : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Priority")]
		[SerializeField]
		private IntegerVar _setPriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setPriority);
		}
		
		public override void Execute()
		{
			_audioSource.Value.priority = _setPriority.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} priority to {_setPriority}";
		}
	}
}
