
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Within the Min distance the AudioSource will cease to grow louder in volume.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-minDistance.html")]
	public sealed class AudioSourceSetMinDistance : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Min Distance")]
		[SerializeField]
		private FloatVar _setMinDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setMinDistance);
		}
		
		public override void Execute()
		{
			_audioSource.Value.minDistance = _setMinDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} min distance to {_setMinDistance}";
		}
	}
}
