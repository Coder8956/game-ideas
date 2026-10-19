
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusVariable : Variable<UnityEngine.BatteryStatus>
	{
		
		public BatteryStatusVariable()
		{
		}
		
		public BatteryStatusVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusListVariable : ListVariable<UnityEngine.BatteryStatus>
	{
		
		public BatteryStatusListVariable()
		{
		}
		
		public BatteryStatusListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusRef : VariableRef<UnityEngine.BatteryStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusVar : VariableVar<UnityEngine.BatteryStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusListRef : ListVariableRef<UnityEngine.BatteryStatus>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BatteryStatus))]
	public sealed partial class BatteryStatusListVar : ListVariableVar<UnityEngine.BatteryStatus>
	{
	}
}
