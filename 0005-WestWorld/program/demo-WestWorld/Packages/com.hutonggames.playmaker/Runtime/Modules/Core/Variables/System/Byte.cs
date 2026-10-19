
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteVariable : Variable<System.Byte>
	{
		
		public ByteVariable()
		{
		}
		
		public ByteVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteListVariable : ListVariable<System.Byte>
	{
		
		public ByteListVariable()
		{
		}
		
		public ByteListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteRef : VariableRef<System.Byte>
	{
	}
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteVar : VariableVar<System.Byte>
	{
	}
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteListRef : ListVariableRef<System.Byte>
	{
	}
	
	[Serializable]
	[DataType(typeof(byte))]
	public sealed partial class ByteListVar : ListVariableVar<System.Byte>
	{
	}
}
