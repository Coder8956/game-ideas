
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Send Event when a PlayableDirector component has paused.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-paused.html")]
	public sealed class PlayableDirectorPausedEvent : BaseOnEventAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Event to send when a PlayableDirector component has paused.")]
		[SerializeField]
		private EventRef _paused;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector);
		}
		
		public override void OnStart()
		{
			_playableDirector.Value.paused += OnPaused;
		}
		
		public override void OnStop()
		{
			_playableDirector.Value.paused -= OnPaused;
		}
		
		private void OnPaused(PlayableDirector obj) => SendEvent(_paused);

		public override string GetSummary() => "On {_playableDirector} paused {_paused}";
	}
}
