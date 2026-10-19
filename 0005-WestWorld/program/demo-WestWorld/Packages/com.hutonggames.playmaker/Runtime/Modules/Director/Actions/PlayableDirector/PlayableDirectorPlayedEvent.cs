
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Send Event when a PlayableDirector component has begun playing.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-played.html")]
	public sealed class PlayableDirectorPlayedEvent : BaseOnEventAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Event to send when a PlayableDirector component has begun playing.")]
		[SerializeField]
		private EventRef _played;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector);
		}
		
		public override void OnStart()
		{
			_playableDirector.Value.played += OnPlayed;
		}
		
		public override void OnStop()
		{
			_playableDirector.Value.played -= OnPlayed;
		}
		
		private void OnPlayed(PlayableDirector obj)
		{
			SendEvent(_played);
		}
		
		public override string GetSummary() => "On {_playableDirector} played {_played}";
	}
}
