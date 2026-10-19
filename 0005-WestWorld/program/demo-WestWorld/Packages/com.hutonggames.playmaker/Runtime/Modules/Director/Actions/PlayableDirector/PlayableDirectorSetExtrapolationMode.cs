
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Controls how the time is incremented when it goes beyond the duration of the play" +
		"able.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-extrapolationMode.html")]
	public sealed class PlayableDirectorSetExtrapolationMode : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Extrapolation Mode")]
		[SerializeField]
		private Playables.DirectorWrapModeVar _setExtrapolationMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _setExtrapolationMode);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.extrapolationMode = _setExtrapolationMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} extrapolation mode to {_setExtrapolationMode}";
		}
	}
}
