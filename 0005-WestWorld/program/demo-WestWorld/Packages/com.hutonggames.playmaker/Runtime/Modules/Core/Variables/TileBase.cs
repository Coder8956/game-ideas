
using System;
using UnityEngine.Tilemaps;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseVariable : Variable<TileBase>
	{
		
		public TileBaseVariable()
		{
		}
		
		public TileBaseVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseListVariable : ListVariable<TileBase>
	{
		
		public TileBaseListVariable()
		{
		}
		
		public TileBaseListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseRef : VariableRef<TileBase>
	{
	}
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseVar : VariableVar<TileBase>
	{
	}
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseListRef : ListVariableRef<TileBase>
	{
	}
	
	[Serializable]
	[DataType(typeof(TileBase))]
	public sealed partial class TileBaseListVar : ListVariableVar<TileBase>
	{
	}
}
