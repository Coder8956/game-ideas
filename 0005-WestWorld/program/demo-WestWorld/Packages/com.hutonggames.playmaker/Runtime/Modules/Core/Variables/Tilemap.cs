
using System;
using UnityEngine.Tilemaps;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapVariable : Variable<Tilemap>
	{
		
		public TilemapVariable()
		{
		}
		
		public TilemapVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapListVariable : ListVariable<Tilemap>
	{
		
		public TilemapListVariable()
		{
		}
		
		public TilemapListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapRef : VariableRef<Tilemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapVar : VariableVar<Tilemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapListRef : ListVariableRef<Tilemap>
	{
	}
	
	[Serializable]
	[DataType(typeof(Tilemap))]
	public sealed partial class TilemapListVar : ListVariableVar<Tilemap>
	{
	}
}
