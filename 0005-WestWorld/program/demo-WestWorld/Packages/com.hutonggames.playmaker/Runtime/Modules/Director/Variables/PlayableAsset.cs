
using System;


namespace HutongGames.PlayMaker.Actions.Playables
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetVariable : Variable<UnityEngine.Playables.PlayableAsset>
	{
		
		public PlayableAssetVariable()
		{
		}
		
		public PlayableAssetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetListVariable : ListVariable<UnityEngine.Playables.PlayableAsset>
	{
		
		public PlayableAssetListVariable()
		{
		}
		
		public PlayableAssetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetRef : VariableRef<UnityEngine.Playables.PlayableAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetVar : VariableVar<UnityEngine.Playables.PlayableAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetListRef : ListVariableRef<UnityEngine.Playables.PlayableAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Playables.PlayableAsset))]
	public sealed partial class PlayableAssetListVar : ListVariableVar<UnityEngine.Playables.PlayableAsset>
	{
	}
}
