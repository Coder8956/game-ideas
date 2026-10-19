
using System;


namespace HutongGames.PlayMaker.Actions.tvOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationVariable : Variable<UnityEngine.tvOS.DeviceGeneration>
	{
		
		public DeviceGenerationVariable()
		{
		}
		
		public DeviceGenerationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListVariable : ListVariable<UnityEngine.tvOS.DeviceGeneration>
	{
		
		public DeviceGenerationListVariable()
		{
		}
		
		public DeviceGenerationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationRef : VariableRef<UnityEngine.tvOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationVar : VariableVar<UnityEngine.tvOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListRef : ListVariableRef<UnityEngine.tvOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListVar : ListVariableVar<UnityEngine.tvOS.DeviceGeneration>
	{
	}
}
