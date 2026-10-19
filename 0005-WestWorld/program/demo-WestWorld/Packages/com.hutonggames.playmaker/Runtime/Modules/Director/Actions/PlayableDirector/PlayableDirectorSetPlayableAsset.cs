
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PlayableDirector)]
	[ActionDescription("The PlayableAsset that is used to instantiate a playable for playback.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-playableAsset.html")]
	public sealed class PlayableDirectorSetPlayableAsset : BaseAction
	{
		
		[Tooltip("The PlayableDirector")]
		[SerializeField]
		private Playables.PlayableDirectorVar _playableDirector;
		
		[Tooltip("Set PlayableDirector Playable Asset")]
		[SerializeField, CanBeNullOrEmpty]
		private Playables.PlayableAssetVar _setPlayableAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_playableDirector);
		}
		
		public override void Execute()
		{
			_playableDirector.Value.playableAsset = _setPlayableAsset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_playableDirector} playable asset to {_setPlayableAsset}";
		}
	}
}
