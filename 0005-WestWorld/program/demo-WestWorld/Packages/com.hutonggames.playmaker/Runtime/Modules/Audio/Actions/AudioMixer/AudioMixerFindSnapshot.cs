
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("The name must be an exact match.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.FindSnapshot.html")]
	public sealed class AudioMixerFindSnapshot : BaseAction
	{
		
		[Tooltip("The AudioMixer.")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Name of snapshot object to be returned.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in AudioMixerSnapshot variable.")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerSnapshotRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _name, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixer.FindSnapshot(System.String);
			_result.Value = _audioMixer.Value.FindSnapshot(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Find Snapshot {_audioMixer} {_name} -> {_result}";
		}
	}
}
