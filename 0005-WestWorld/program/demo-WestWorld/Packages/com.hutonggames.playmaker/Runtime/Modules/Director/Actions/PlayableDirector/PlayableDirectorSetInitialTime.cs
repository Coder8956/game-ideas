
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The time at which the Playable should start when first played.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-initialTime.html")]
	public sealed class PlayableDirectorSetInitialTime : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Initial Time")]
		[SerializeField]
		private DoubleVar _setInitialTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _setInitialTime);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.initialTime = _setInitialTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} initial time to {_setInitialTime}";
		}
	}
}
