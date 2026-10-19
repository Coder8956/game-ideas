
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Resume playing a paused playable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Resume.html")]
	public sealed class PlayableDirectorResume : BaseAction
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
			//UnityEngine.Playables.PlayableDirector.Resume();
			_playableDirector.Value.Resume();
		}
		
		public override string GetSummary()
		{
			return "Resume {_playableDirector}";
		}
	}
}
