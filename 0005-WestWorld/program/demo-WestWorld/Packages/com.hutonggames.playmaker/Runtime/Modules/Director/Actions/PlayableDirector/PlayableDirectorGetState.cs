
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The current playing state of the component. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-state.html")]
	public sealed class PlayableDirectorGetState : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector State")]
		[SerializeField]
		[WriteOnly]
		private Playables.PlayStateRef _getState;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getState);
		}
		
		public override void Execute()
		{
			_getState.Value = _playableDirector.Value.state;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} state -> {_getState}";
		}
	}
}
