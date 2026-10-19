
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Stops playback of the current Playable and destroys the corresponding graph.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Stop.html")]
	public sealed class PlayableDirectorStop : BaseAction
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
			//UnityEngine.Playables.PlayableDirector.Stop();
			_playableDirector.Value.Stop();
		}
		
		public override string GetSummary()
		{
			return "Stop {_playableDirector}";
		}
	}
}
