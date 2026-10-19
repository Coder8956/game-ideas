
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioListener)]
	[ActionDescription("The paused state of the audio system.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioListener-pause.html")]
	public sealed class AudioListenerSetPause : BaseAction
	{
		
		[Tooltip("Set AudioListener Pause")]
		[SerializeField]
		private BoolVar _setPause;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setPause);
		}
		
		public override void Execute()
		{
			AudioListener.pause = _setPause.Value;
		}
		
		public override string GetSummary()
		{
			return "Set AudioListener pause to {_setPause}";
		}
	}
}
