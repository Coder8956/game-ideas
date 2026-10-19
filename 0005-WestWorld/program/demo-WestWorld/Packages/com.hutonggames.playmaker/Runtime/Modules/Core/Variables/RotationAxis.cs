using System;

namespace HutongGames.PlayMaker
{
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }
    
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisVariable : Variable<RotationAxis>
	{
		
		public RotationAxisVariable()
		{
		}
		
		public RotationAxisVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisListVariable : ListVariable<RotationAxis>
	{
		
		public RotationAxisListVariable()
		{
		}
		
		public RotationAxisListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisRef : VariableRef<RotationAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisVar : VariableVar<RotationAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisListRef : ListVariableRef<RotationAxis>
	{
	}
	
	[Serializable]
	[DataType(typeof(RotationAxis))]
	public sealed partial class RotationAxisListVar : ListVariableVar<RotationAxis>
	{
	}
}