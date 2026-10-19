
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixerSnapshot)]
	[ActionDescription("Performs an interpolated transition towards this snapshot over the time interval specified.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixerSnapshot.TransitionTo.html")]
	public sealed class AudioMixerSnapshotTransitionTo : BaseAction
	{
		
		[Tooltip("The AudioMixerSnapshot.")]
		[SerializeField]
		private AudioMixerSnapshotVar _audioMixerSnapshot;
		
		[Tooltip("Relative time after which this snapshot should be reached from any current state.")]
		[SerializeField]
		private FloatVar _timeToReach;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixerSnapshot, _timeToReach);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixerSnapshot.TransitionTo(System.Single);
			_audioMixerSnapshot.Value.TransitionTo(_timeToReach.Value);
		}
		
		public override string GetSummary()
		{
			return "Transition To {_audioMixerSnapshot} {_timeToReach} ";
		}
	}
}
