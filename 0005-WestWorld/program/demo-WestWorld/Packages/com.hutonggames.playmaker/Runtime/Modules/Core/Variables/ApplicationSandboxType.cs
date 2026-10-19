
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeVariable : Variable<UnityEngine.ApplicationSandboxType>
	{
		
		public ApplicationSandboxTypeVariable()
		{
		}
		
		public ApplicationSandboxTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeListVariable : ListVariable<UnityEngine.ApplicationSandboxType>
	{
		
		public ApplicationSandboxTypeListVariable()
		{
		}
		
		public ApplicationSandboxTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeRef : VariableRef<UnityEngine.ApplicationSandboxType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeVar : VariableVar<UnityEngine.ApplicationSandboxType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeListRef : ListVariableRef<UnityEngine.ApplicationSandboxType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationSandboxType))]
	public sealed partial class ApplicationSandboxTypeListVar : ListVariableVar<UnityEngine.ApplicationSandboxType>
	{
	}
}
