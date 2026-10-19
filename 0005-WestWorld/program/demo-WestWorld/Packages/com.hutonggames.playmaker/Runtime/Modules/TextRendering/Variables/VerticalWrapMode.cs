
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeVariable : Variable<UnityEngine.VerticalWrapMode>
	{
		
		public VerticalWrapModeVariable()
		{
		}
		
		public VerticalWrapModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeListVariable : ListVariable<UnityEngine.VerticalWrapMode>
	{
		
		public VerticalWrapModeListVariable()
		{
		}
		
		public VerticalWrapModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeRef : VariableRef<UnityEngine.VerticalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeVar : VariableVar<UnityEngine.VerticalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeListRef : ListVariableRef<UnityEngine.VerticalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VerticalWrapMode))]
	public sealed partial class VerticalWrapModeListVar : ListVariableVar<UnityEngine.VerticalWrapMode>
	{
	}
}
