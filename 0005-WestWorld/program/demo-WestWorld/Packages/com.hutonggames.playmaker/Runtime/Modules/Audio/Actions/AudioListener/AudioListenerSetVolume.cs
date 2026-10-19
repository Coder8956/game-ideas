
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioListener)]
	[ActionDescription("Controls the game sound volume (0.0 to 1.0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioListener-volume.html")]
	public sealed class AudioListenerSetVolume : BaseAction
	{
		
		[Tooltip("Set AudioListener Volume")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _setVolume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setVolume);
		}
		
		public override void Execute()
		{
			AudioListener.volume = _setVolume.Value;
		}
		
		public override string GetSummary()
		{
			return "Set AudioListener volume to {_setVolume}";
		}
	}
}
