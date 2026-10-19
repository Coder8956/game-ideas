
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
	public sealed class AudioListenerGetVolume : BaseAction
	{
		
		[Tooltip("Get AudioListener Volume")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getVolume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getVolume);
		}
		
		public override void Execute()
		{
			_getVolume.Value = AudioListener.volume;
		}
		
		public override string GetSummary()
		{
			return "Get AudioListener volume -> {_getVolume}";
		}
	}
}
