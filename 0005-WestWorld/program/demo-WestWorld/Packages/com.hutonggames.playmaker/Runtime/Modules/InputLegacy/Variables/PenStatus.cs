
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusVariable : Variable<UnityEngine.PenStatus>
	{
		
		public PenStatusVariable()
		{
		}
		
		public PenStatusVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusListVariable : ListVariable<UnityEngine.PenStatus>
	{
		
		public PenStatusListVariable()
		{
		}
		
		public PenStatusListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusRef : VariableRef<UnityEngine.PenStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusVar : VariableVar<UnityEngine.PenStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusListRef : ListVariableRef<UnityEngine.PenStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PenStatus))]
	public sealed partial class PenStatusListVar : ListVariableVar<UnityEngine.PenStatus>
	{
	}
}
