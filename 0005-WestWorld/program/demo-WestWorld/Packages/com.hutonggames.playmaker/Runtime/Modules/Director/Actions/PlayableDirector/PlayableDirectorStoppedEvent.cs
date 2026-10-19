
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Send Event when a PlayableDirector component has stopped.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-stopped.html")]
	public sealed class PlayableDirectorStoppedEvent : BaseOnEventAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Event to send when a PlayableDirector component has stopped.")]
		[SerializeField]
		private EventRef _stopped;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector);
		}
		
		public override void OnStart()
		{
			_playableDirector.Value.stopped += OnStopped;
		}
		
		public override void OnStop()
		{
			_playableDirector.Value.stopped -= OnStopped;
		}
		
		private void OnStopped(PlayableDirector obj)
		{
			SendEvent(_stopped);
		}
		
		public override string GetSummary() => "On {_playableDirector} stopped {_stopped}";
	}
}
