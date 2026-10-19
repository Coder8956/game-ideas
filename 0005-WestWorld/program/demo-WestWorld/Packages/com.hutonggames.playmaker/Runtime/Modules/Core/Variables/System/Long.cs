
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongVariable : Variable<long>
	{
		
		public LongVariable()
		{
		}
		
		public LongVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongListVariable : ListVariable<long>
	{
		
		public LongListVariable()
		{
		}
		
		public LongListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongRef : VariableRef<long>
	{
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongVar : VariableVar<long>
	{
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongListRef : ListVariableRef<long>
	{
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongListVar : ListVariableVar<long>
	{
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongOverride : VariableOverride<long,LongVariable,LongVar>
	{
		
		public LongOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(long))]
	public sealed partial class LongOutput : VariableOutput<long,LongVariable,LongRef>
	{
		
		public LongOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
