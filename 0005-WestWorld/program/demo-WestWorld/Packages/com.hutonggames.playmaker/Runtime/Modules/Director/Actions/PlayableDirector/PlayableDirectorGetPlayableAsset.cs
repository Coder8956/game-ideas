
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The PlayableAsset that is used to instantiate a playable for playback.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-playableAsset.html")]
	public sealed class PlayableDirectorGetPlayableAsset : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Get PlayableDirector Playable Asset")]
		[SerializeField]
		[WriteOnly]
		private Playables.PlayableAssetRef _getPlayableAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _getPlayableAsset);
		}
		
		public override void Execute()
		{
			_getPlayableAsset.Value = _playableDirector.Value.playableAsset;
		}
		
		public override string GetSummary()
		{
			return "Get {_playableDirector} playable asset -> {_getPlayableAsset}";
		}
	}
}
