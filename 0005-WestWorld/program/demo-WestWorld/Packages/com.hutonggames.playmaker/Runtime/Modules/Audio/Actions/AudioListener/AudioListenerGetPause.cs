
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
	public sealed class AudioListenerGetPause : BaseAction
	{
		
		[Tooltip("Get AudioListener Pause")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getPause;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPause);
		}
		
		public override void Execute()
		{
			_getPause.Value = AudioListener.pause;
		}
		
		public override string GetSummary()
		{
			return "Get AudioListener pause -> {_getPause}";
		}
	}
}
