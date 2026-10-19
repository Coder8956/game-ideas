
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
	public sealed class PlayableDirectorGetTime : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Time")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getTime);
		}
		
		public override void Execute()
		{
			_getTime.Value = _playableDirector.Value.time;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} time -> {_getTime}";
		}
	}
}
