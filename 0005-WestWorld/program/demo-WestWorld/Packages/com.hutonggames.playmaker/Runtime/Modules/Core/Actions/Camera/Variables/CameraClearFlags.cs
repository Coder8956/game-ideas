
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsVariable : Variable<UnityEngine.CameraClearFlags>
	{
		
		public CameraClearFlagsVariable()
		{
		}
		
		public CameraClearFlagsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsListVariable : ListVariable<UnityEngine.CameraClearFlags>
	{
		
		public CameraClearFlagsListVariable()
		{
		}
		
		public CameraClearFlagsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsRef : VariableRef<UnityEngine.CameraClearFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsVar : VariableVar<UnityEngine.CameraClearFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsListRef : ListVariableRef<UnityEngine.CameraClearFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CameraClearFlags))]
	public sealed partial class CameraClearFlagsListVar : ListVariableVar<UnityEngine.CameraClearFlags>
	{
	}
}
