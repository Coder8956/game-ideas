
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The time at which the Playable should start when first played.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-initialTime.html")]
	public sealed class PlayableDirectorGetInitialTime : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Initial Time")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getInitialTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getInitialTime);
		}
		
		public override void Execute()
		{
			_getInitialTime.Value = _playableDirector.Value.initialTime;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} initial time -> {_getInitialTime}";
		}
	}
}
