
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageVariable : Variable<UnityEngine.Rendering.ReflectionProbeUsage>
	{
		
		public ReflectionProbeUsageVariable()
		{
		}
		
		public ReflectionProbeUsageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageListVariable : ListVariable<UnityEngine.Rendering.ReflectionProbeUsage>
	{
		
		public ReflectionProbeUsageListVariable()
		{
		}
		
		public ReflectionProbeUsageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageRef : VariableRef<UnityEngine.Rendering.ReflectionProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageVar : VariableVar<UnityEngine.Rendering.ReflectionProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageListRef : ListVariableRef<UnityEngine.Rendering.ReflectionProbeUsage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeUsage))]
	public sealed partial class ReflectionProbeUsageListVar : ListVariableVar<UnityEngine.Rendering.ReflectionProbeUsage>
	{
	}
}
