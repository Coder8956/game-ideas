
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Controls how time is incremented when playing back.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-timeUpdateMode.html")]
	public sealed class PlayableDirectorGetTimeUpdateMode : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Time Update Mode")]
		[SerializeField]
		[WriteOnly]
		private Playables.DirectorUpdateModeRef _getTimeUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getTimeUpdateMode);
		}
		
		public override void Execute()
		{
			_getTimeUpdateMode.Value = _playableDirector.Value.timeUpdateMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} time update mode -> {_getTimeUpdateMode}";
		}
	}
}
