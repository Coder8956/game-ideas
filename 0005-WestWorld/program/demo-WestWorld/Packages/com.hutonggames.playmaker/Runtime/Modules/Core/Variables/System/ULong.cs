
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongVariable : Variable<ulong>
	{
		
		public ULongVariable()
		{
		}
		
		public ULongVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongListVariable : ListVariable<ulong>
	{
		
		public ULongListVariable()
		{
		}
		
		public ULongListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongRef : VariableRef<ulong>
	{
	}
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongVar : VariableVar<ulong>
	{
	}
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongListRef : ListVariableRef<ulong>
	{
	}
	
	[Serializable]
	[DataType(typeof(ulong))]
	public sealed partial class ULongListVar : ListVariableVar<ulong>
	{
	}
}
