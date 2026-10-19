
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The component\'s current time. This value is incremented according to the Playable" +
		"Director.timeUpdateMode when it is playing. You can also change this value manually.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-time.html")]
	public sealed class PlayableDirectorSetTime : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Time")]
		[SerializeField]
		private DoubleVar _setTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _setTime);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.time = _setTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} time to {_setTime}";
		}
	}
}
