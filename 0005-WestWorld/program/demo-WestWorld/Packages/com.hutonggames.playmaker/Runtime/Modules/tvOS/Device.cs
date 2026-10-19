
using System;


namespace HutongGames.PlayMaker.Actions.tvOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceVariable : Variable<UnityEngine.tvOS.Device>
	{
		
		public DeviceVariable()
		{
		}
		
		public DeviceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceListVariable : ListVariable<UnityEngine.tvOS.Device>
	{
		
		public DeviceListVariable()
		{
		}
		
		public DeviceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceRef : VariableRef<UnityEngine.tvOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceVar : VariableVar<UnityEngine.tvOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceListRef : ListVariableRef<UnityEngine.tvOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.tvOS.Device))]
	public sealed partial class DeviceListVar : ListVariableVar<UnityEngine.tvOS.Device>
	{
	}
}
