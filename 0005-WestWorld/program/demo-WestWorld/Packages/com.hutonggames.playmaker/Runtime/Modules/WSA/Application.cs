
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationVariable : Variable<UnityEngine.WSA.Application>
	{
		
		public ApplicationVariable()
		{
		}
		
		public ApplicationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationListVariable : ListVariable<UnityEngine.WSA.Application>
	{
		
		public ApplicationListVariable()
		{
		}
		
		public ApplicationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationRef : VariableRef<UnityEngine.WSA.Application>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationVar : VariableVar<UnityEngine.WSA.Application>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationListRef : ListVariableRef<UnityEngine.WSA.Application>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Application))]
	public sealed partial class ApplicationListVar : ListVariableVar<UnityEngine.WSA.Application>
	{
	}
}
