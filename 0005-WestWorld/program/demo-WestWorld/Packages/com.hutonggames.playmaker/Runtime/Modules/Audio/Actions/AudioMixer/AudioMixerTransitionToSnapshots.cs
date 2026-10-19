
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Audio;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("Transitions to a weighted mixture of the snapshots specified. This can be used for " +
		"games that specify the game state as a continuum between states or for interpolating snapshots from a triangulated map location.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.TransitionToSnapshots.html")]
	public sealed class AudioMixerTransitionToSnapshots : BaseAction
	{
		
		[Tooltip("The AudioMixer.")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("The set of snapshots to be mixed.")]
		[SerializeField]
		private AudioMixerSnapshotListVar _snapshots;
		
		[Tooltip("The mix weights for the snapshots specified.")]
		[SerializeField]
		private FloatListVar _weights;
		
		[Tooltip("Relative time after which the mixture should be reached from any current state.")]
		[SerializeField]
		private FloatVar _timeToReach;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _snapshots, _weights, _timeToReach);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixer.TransitionToSnapshots(UnityEngine.Audio.AudioMixerSnapshot[], System.Single[], System.Single);
			_audioMixer.Value.TransitionToSnapshots(_snapshots.Values, _weights.Values, _timeToReach.Value);
		}
		
		public override string GetSummary()
		{
			return "Transition To Snapshots {_audioMixer} {_snapshots} {_weights} {_timeToReach} ";
		}
	}
}
