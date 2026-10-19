
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Starts playback.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Play.html")]
	public sealed class PlayableDirectorPlay : BaseAction
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
			//UnityEngine.Playables.PlayableDirector.Play();
			_playableDirector.Value.Play();
		}
		
		public override string GetSummary()
		{
			return "Play {_playableDirector}";
		}
	}
}
