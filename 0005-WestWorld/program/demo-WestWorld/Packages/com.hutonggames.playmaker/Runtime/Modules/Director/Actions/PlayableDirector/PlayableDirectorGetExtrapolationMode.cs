
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Controls how the time is incremented when it goes beyond the duration of the playable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-extrapolation" +
		"Mode.html")]
	public sealed class PlayableDirectorGetExtrapolationMode : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Extrapolation Mode")]
		[SerializeField]
		[WriteOnly]
		private Playables.DirectorWrapModeRef _getExtrapolationMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getExtrapolationMode);
		}
		
		public override void Execute()
		{
			_getExtrapolationMode.Value = _playableDirector.Value.extrapolationMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} extrapolation mode -> {_getExtrapolationMode}";
		}
	}
}
