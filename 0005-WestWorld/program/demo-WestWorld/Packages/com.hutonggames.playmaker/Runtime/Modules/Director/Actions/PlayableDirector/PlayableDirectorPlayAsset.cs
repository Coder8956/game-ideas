
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("Instantiates a Playable using the provided PlayableAsset and starts playback.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Play.html")]
	public sealed class PlayableDirectorPlayAsset : BaseAction
	{
		
		[Tooltip("The PlayableDirector.")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("An asset to instantiate a playable from.")]
		[SerializeField]
		private Playables.PlayableAssetVar _asset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector, _asset);
		}
		
		public override void Execute()
		{
			//UnityEngine.Playables.PlayableDirector.Play(UnityEngine.Playables.PlayableAsset);
			_playableDirector.Value.Play(_asset.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_asset} on {_playableDirector}";
		}
	}
}
