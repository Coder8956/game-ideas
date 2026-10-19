
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-maxDistance.html")]
	public sealed class AudioSourceSetMaxDistance : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Max Distance")]
		[SerializeField]
		private FloatVar _setMaxDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setMaxDistance);
		}
		
		public override void Execute()
		{
			_audioSource.Value.maxDistance = _setMaxDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} max distance to {_setMaxDistance}";
		}
	}
}
