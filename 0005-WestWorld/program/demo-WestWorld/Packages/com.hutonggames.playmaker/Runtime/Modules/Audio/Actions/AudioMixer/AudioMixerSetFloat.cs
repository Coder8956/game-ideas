
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("Sets the value of the exposed parameter specified. When a parameter is exposed, " +
		"it is not controlled by mixer snapshots. You can only change the parameter with this function.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.SetFloat.html")]
	public sealed class AudioMixerSetFloat : BaseAction
	{
		
		[Tooltip("The AudioMixer.")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("The name of an exposed Audio Mixer group parameter. To expose a parameter, go to " +
			"the Audio Mixer group\'s Inspector window, right click the parameter you want to " +
			"expose, and choose Expose [parameter name] to script.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Use to set the exposed Audio Mixer group parameter to a new value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _name, _value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Audio.AudioMixer.SetFloat(System.String, System.Single);
			_result.Value = _audioMixer.Value.SetFloat(_name.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Float {_audioMixer} {_name} {_value} -> {_result}";
		}
	}
}
