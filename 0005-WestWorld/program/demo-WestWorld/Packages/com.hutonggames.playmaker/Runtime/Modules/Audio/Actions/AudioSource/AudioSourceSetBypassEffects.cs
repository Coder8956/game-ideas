
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Bypass effects (Applied from filter components or global listener filters).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-bypassEffects.html")]
	public sealed class AudioSourceSetBypassEffects : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Bypass Effects")]
		[SerializeField]
		private BoolVar _setBypassEffects;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setBypassEffects);
		}
		
		public override void Execute()
		{
			_audioSource.Value.bypassEffects = _setBypassEffects.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} bypass effects to {_setBypassEffects}";
		}
	}
}
