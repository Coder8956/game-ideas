
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("Resets an exposed parameter to its initial value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.ClearFloat.html")]
	public sealed class AudioMixerClearFloat : BaseAction
	{
		
		[Tooltip("The AudioMixer.")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Exposed parameter.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _name, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixer.ClearFloat(System.String);
			_result.Value = _audioMixer.Value.ClearFloat(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Clear Float {_audioMixer} {_name} -> {_result}";
		}
	}
}
