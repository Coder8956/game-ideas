
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Instantiates a Playable using the provided PlayableAsset and starts playback.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Play.html")]
	public sealed class PlayableDirectorPlayAsset__Mode : BaseAction
	{
		
		[Tooltip("The PlayableDirector.")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("An asset to instantiate a playable from.")]
		[SerializeField]
		private Playables.PlayableAssetVar _asset;
		
		[Tooltip("What to do when the time passes the duration of the playable.")]
		[SerializeField]
		private Playables.DirectorWrapModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _asset, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Playables.PlayableDirector.Play(UnityEngine.Playables.PlayableAsset, UnityEngine.Playables.DirectorWrapMode);
			_playableDirector.Value.Play(_asset.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_asset} on {_playableDirector} {_mode}";
		}
	}
}
