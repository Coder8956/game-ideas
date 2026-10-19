
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageVariable : Variable<UnityEngine.VRTextureUsage>
	{
		
		public VRTextureUsageVariable()
		{
		}
		
		public VRTextureUsageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageListVariable : ListVariable<UnityEngine.VRTextureUsage>
	{
		
		public VRTextureUsageListVariable()
		{
		}
		
		public VRTextureUsageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageRef : VariableRef<UnityEngine.VRTextureUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageVar : VariableVar<UnityEngine.VRTextureUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageListRef : ListVariableRef<UnityEngine.VRTextureUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.VRTextureUsage))]
	public sealed partial class VRTextureUsageListVar : ListVariableVar<UnityEngine.VRTextureUsage>
	{
	}
}
