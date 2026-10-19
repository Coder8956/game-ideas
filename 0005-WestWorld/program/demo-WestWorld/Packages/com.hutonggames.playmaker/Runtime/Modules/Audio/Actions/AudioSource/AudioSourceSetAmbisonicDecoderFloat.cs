
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets a user-defined parameter of a custom ambisonic decoder effect that is attached to an AudioSource.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.SetAmbisonicDecoderFloat.html")]
	public sealed class AudioSourceSetAmbisonicDecoderFloat : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Zero-based index of user-defined parameter to be set.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("New value of the user-defined parameter.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _index, _value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.SetAmbisonicDecoderFloat(System.Int32, System.Single);
			_result.Value = _audioSource.Value.SetAmbisonicDecoderFloat(_index.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} ambisonic decoder float {_index} to {_value} -> {_result}";
		}
	}
}
