
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleVariable : Variable<Double>
	{
		
		public DoubleVariable()
		{
		}
		
		public DoubleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleListVariable : ListVariable<Double>
	{
		
		public DoubleListVariable()
		{
		}
		
		public DoubleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleRef : VariableRef<Double>
	{
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleVar : VariableVar<Double>
	{
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleListRef : ListVariableRef<Double>
	{
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleListVar : ListVariableVar<Double>
	{
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleOverride : VariableOverride<Double,DoubleVariable,DoubleVar>
	{
		
		public DoubleOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(double))]
	public sealed partial class DoubleOutput : VariableOutput<Double,DoubleVariable,DoubleRef>
	{
		
		public DoubleOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
