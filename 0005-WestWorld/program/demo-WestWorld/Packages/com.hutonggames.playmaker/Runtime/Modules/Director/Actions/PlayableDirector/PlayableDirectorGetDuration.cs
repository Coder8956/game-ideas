
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The duration of the currently connected Playable in seconds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-duration.html" +
		"")]
	public sealed class PlayableDirectorGetDuration : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Duration")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getDuration;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getDuration);
		}
		
		public override void Execute()
		{
			_getDuration.Value = _playableDirector.Value.duration;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} duration -> {_getDuration}";
		}
	}
}
