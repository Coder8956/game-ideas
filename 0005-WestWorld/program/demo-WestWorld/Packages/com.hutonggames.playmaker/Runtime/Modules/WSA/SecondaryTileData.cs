
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataVariable : Variable<UnityEngine.WSA.SecondaryTileData>
	{
		
		public SecondaryTileDataVariable()
		{
		}
		
		public SecondaryTileDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataListVariable : ListVariable<UnityEngine.WSA.SecondaryTileData>
	{
		
		public SecondaryTileDataListVariable()
		{
		}
		
		public SecondaryTileDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataRef : VariableRef<UnityEngine.WSA.SecondaryTileData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataVar : VariableVar<UnityEngine.WSA.SecondaryTileData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataListRef : ListVariableRef<UnityEngine.WSA.SecondaryTileData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.SecondaryTileData))]
	public sealed partial class SecondaryTileDataListVar : ListVariableVar<UnityEngine.WSA.SecondaryTileData>
	{
	}
}
