
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
	public sealed class PlayableDirectorSetPlayOnAwake : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Play On Awake")]
		[SerializeField]
		private BoolVar _setPlayOnAwake;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _setPlayOnAwake);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.playOnAwake = _setPlayOnAwake.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} play on awake to {_setPlayOnAwake}";
		}
	}
}
