
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsVariable : Variable<UnityEngine.HDRDisplaySupportFlags>
	{
		
		public HDRDisplaySupportFlagsVariable()
		{
		}
		
		public HDRDisplaySupportFlagsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsListVariable : ListVariable<UnityEngine.HDRDisplaySupportFlags>
	{
		
		public HDRDisplaySupportFlagsListVariable()
		{
		}
		
		public HDRDisplaySupportFlagsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsRef : VariableRef<UnityEngine.HDRDisplaySupportFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsVar : VariableVar<UnityEngine.HDRDisplaySupportFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsListRef : ListVariableRef<UnityEngine.HDRDisplaySupportFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HDRDisplaySupportFlags))]
	public sealed partial class HDRDisplaySupportFlagsListVar : ListVariableVar<UnityEngine.HDRDisplaySupportFlags>
	{
	}
}
