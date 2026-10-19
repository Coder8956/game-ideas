
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeVariable : Variable<UnityEngine.DeviceType>
	{
		
		public DeviceTypeVariable()
		{
		}
		
		public DeviceTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeListVariable : ListVariable<UnityEngine.DeviceType>
	{
		
		public DeviceTypeListVariable()
		{
		}
		
		public DeviceTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeRef : VariableRef<UnityEngine.DeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeVar : VariableVar<UnityEngine.DeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeListRef : ListVariableRef<UnityEngine.DeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceType))]
	public sealed partial class DeviceTypeListVar : ListVariableVar<UnityEngine.DeviceType>
	{
	}
}
