
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageVariable : Variable<UnityEngine.Rendering.LightProbeUsage>
	{
		
		public LightProbeUsageVariable()
		{
		}
		
		public LightProbeUsageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageListVariable : ListVariable<UnityEngine.Rendering.LightProbeUsage>
	{
		
		public LightProbeUsageListVariable()
		{
		}
		
		public LightProbeUsageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageRef : VariableRef<UnityEngine.Rendering.LightProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageVar : VariableVar<UnityEngine.Rendering.LightProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageListRef : ListVariableRef<UnityEngine.Rendering.LightProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightProbeUsage))]
	public sealed partial class LightProbeUsageListVar : ListVariableVar<UnityEngine.Rendering.LightProbeUsage>
	{
	}
}
