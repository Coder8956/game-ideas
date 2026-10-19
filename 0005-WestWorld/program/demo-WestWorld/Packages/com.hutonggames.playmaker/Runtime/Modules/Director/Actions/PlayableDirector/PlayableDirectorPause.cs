
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Pauses playback of the currently running playable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Pause.html")]
	public sealed class PlayableDirectorPause : BaseAction
	{
		
		[Tooltip("The PlayableDirector.")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector);
		}
		
		public override void Execute()
		{
			//UnityEngine.Playables.PlayableDirector.Pause();
			_playableDirector.Value.Pause();
		}
		
		public override string GetSummary()
		{
			return "Pause {_playableDirector}";
		}
	}
}
