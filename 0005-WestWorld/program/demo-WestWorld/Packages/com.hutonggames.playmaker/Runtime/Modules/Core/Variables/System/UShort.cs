
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortVariable : Variable<ushort>
	{
		
		public UShortVariable()
		{
		}
		
		public UShortVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortListVariable : ListVariable<ushort>
	{
		
		public UShortListVariable()
		{
		}
		
		public UShortListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortRef : VariableRef<ushort>
	{
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortVar : VariableVar<ushort>
	{
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortListRef : ListVariableRef<ushort>
	{
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortListVar : ListVariableVar<ushort>
	{
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortOverride : VariableOverride<ushort,UShortVariable,UShortVar>
	{
		
		public UShortOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ushort))]
	public sealed partial class UShortOutput : VariableOutput<ushort,UShortVariable,UShortRef>
	{
		
		public UShortOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
