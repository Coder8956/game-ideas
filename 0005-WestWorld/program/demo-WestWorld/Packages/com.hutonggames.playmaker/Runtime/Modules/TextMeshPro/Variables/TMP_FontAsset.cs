
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetVariable : Variable<TMPro.TMP_FontAsset>
	{
		
		public TMP_FontAssetVariable()
		{
		}
		
		public TMP_FontAssetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetListVariable : ListVariable<TMPro.TMP_FontAsset>
	{
		
		public TMP_FontAssetListVariable()
		{
		}
		
		public TMP_FontAssetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetRef : VariableRef<TMPro.TMP_FontAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetVar : VariableVar<TMPro.TMP_FontAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetListRef : ListVariableRef<TMPro.TMP_FontAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_FontAsset))]
	public sealed partial class TMP_FontAssetListVar : ListVariableVar<TMPro.TMP_FontAsset>
	{
	}
}
