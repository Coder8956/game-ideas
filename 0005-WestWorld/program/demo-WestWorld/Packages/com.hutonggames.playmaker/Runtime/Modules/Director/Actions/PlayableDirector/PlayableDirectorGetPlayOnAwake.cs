
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Whether the playable asset will start playing back as soon as the component awake" +
		"s.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-playOnAwake.html")]
	public sealed class PlayableDirectorGetPlayOnAwake : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Play On Awake")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getPlayOnAwake;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getPlayOnAwake);
		}
		
		public override void Execute()
		{
			_getPlayOnAwake.Value = _playableDirector.Value.playOnAwake;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} play on awake -> {_getPlayOnAwake}";
		}
	}
}
