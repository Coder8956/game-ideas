
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntVariable : Variable<uint>
	{
		
		public UIntVariable()
		{
		}
		
		public UIntVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntListVariable : ListVariable<uint>
	{
		
		public UIntListVariable()
		{
		}
		
		public UIntListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntRef : VariableRef<uint>
	{
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntVar : VariableVar<uint>
	{
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntListRef : ListVariableRef<uint>
	{
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntListVar : ListVariableVar<uint>
	{
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntOverride : VariableOverride<uint,UIntVariable,UIntVar>
	{
		
		public UIntOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(uint))]
	public sealed partial class UIntOutput : VariableOutput<uint,UIntVariable,UIntRef>
	{
		
		public UIntOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
