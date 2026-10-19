
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataVariable : Variable<UnityEngine.PenData>
	{
		
		public PenDataVariable()
		{
		}
		
		public PenDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataListVariable : ListVariable<UnityEngine.PenData>
	{
		
		public PenDataListVariable()
		{
		}
		
		public PenDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataRef : VariableRef<UnityEngine.PenData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataVar : VariableVar<UnityEngine.PenData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataListRef : ListVariableRef<UnityEngine.PenData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenData))]
	public sealed partial class PenDataListVar : ListVariableVar<UnityEngine.PenData>
	{
	}
}
