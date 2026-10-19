
using System;


namespace HutongGames.PlayMaker.Actions.iOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationVariable : Variable<UnityEngine.iOS.DeviceGeneration>
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
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListVariable : ListVariable<UnityEngine.iOS.DeviceGeneration>
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
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationRef : VariableRef<UnityEngine.iOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationVar : VariableVar<UnityEngine.iOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListRef : ListVariableRef<UnityEngine.iOS.DeviceGeneration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.DeviceGeneration))]
	public sealed partial class DeviceGenerationListVar : ListVariableVar<UnityEngine.iOS.DeviceGeneration>
	{
	}
}
