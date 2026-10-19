
using System;


namespace HutongGames.PlayMaker.Actions.iOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceVariable : Variable<UnityEngine.iOS.Device>
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
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceListVariable : ListVariable<UnityEngine.iOS.Device>
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
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceRef : VariableRef<UnityEngine.iOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceVar : VariableVar<UnityEngine.iOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceListRef : ListVariableRef<UnityEngine.iOS.Device>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.Device))]
	public sealed partial class DeviceListVar : ListVariableVar<UnityEngine.iOS.Device>
	{
	}
}
