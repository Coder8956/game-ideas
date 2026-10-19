
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformVariable : Variable<UnityEngine.RuntimePlatform>
	{
		
		public RuntimePlatformVariable()
		{
		}
		
		public RuntimePlatformVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformListVariable : ListVariable<UnityEngine.RuntimePlatform>
	{
		
		public RuntimePlatformListVariable()
		{
		}
		
		public RuntimePlatformListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformRef : VariableRef<UnityEngine.RuntimePlatform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformVar : VariableVar<UnityEngine.RuntimePlatform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformListRef : ListVariableRef<UnityEngine.RuntimePlatform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimePlatform))]
	public sealed partial class RuntimePlatformListVar : ListVariableVar<UnityEngine.RuntimePlatform>
	{
	}
}
