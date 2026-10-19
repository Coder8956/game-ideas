
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationVariable : Variable<UnityEngine.DeviceOrientation>
	{
		
		public DeviceOrientationVariable()
		{
		}
		
		public DeviceOrientationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationListVariable : ListVariable<UnityEngine.DeviceOrientation>
	{
		
		public DeviceOrientationListVariable()
		{
		}
		
		public DeviceOrientationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationRef : VariableRef<UnityEngine.DeviceOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationVar : VariableVar<UnityEngine.DeviceOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationListRef : ListVariableRef<UnityEngine.DeviceOrientation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DeviceOrientation))]
	public sealed partial class DeviceOrientationListVar : ListVariableVar<UnityEngine.DeviceOrientation>
	{
	}
}
