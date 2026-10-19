
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Controls how time is incremented when playing back.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-timeUpdateMode.html")]
	public sealed class PlayableDirectorSetTimeUpdateMode : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Time Update Mode")]
		[SerializeField]
		private Playables.DirectorUpdateModeVar _setTimeUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _setTimeUpdateMode);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.timeUpdateMode = _setTimeUpdateMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} time update mode to {_setTimeUpdateMode}";
		}
	}
}
