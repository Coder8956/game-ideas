
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetVariable : Variable<TMPro.TMP_SpriteAsset>
	{
		
		public TMP_SpriteAssetVariable()
		{
		}
		
		public TMP_SpriteAssetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetListVariable : ListVariable<TMPro.TMP_SpriteAsset>
	{
		
		public TMP_SpriteAssetListVariable()
		{
		}
		
		public TMP_SpriteAssetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetRef : VariableRef<TMPro.TMP_SpriteAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetVar : VariableVar<TMPro.TMP_SpriteAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetListRef : ListVariableRef<TMPro.TMP_SpriteAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAsset))]
	public sealed partial class TMP_SpriteAssetListVar : ListVariableVar<TMPro.TMP_SpriteAsset>
	{
	}
}
