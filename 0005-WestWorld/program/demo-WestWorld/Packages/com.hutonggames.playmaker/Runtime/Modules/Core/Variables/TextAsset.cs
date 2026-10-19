
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetVariable : Variable<UnityEngine.TextAsset>
	{
		
		public TextAssetVariable()
		{
		}
		
		public TextAssetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetListVariable : ListVariable<UnityEngine.TextAsset>
	{
		
		public TextAssetListVariable()
		{
		}
		
		public TextAssetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetRef : VariableRef<UnityEngine.TextAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetVar : VariableVar<UnityEngine.TextAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetListRef : ListVariableRef<UnityEngine.TextAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TextAsset))]
	public sealed partial class TextAssetListVar : ListVariableVar<UnityEngine.TextAsset>
	{
	}
}
