
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeVariable : Variable<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
		
		public RayTracingModeVariable()
		{
		}
		
		public RayTracingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeListVariable : ListVariable<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
		
		public RayTracingModeListVariable()
		{
		}
		
		public RayTracingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeRef : VariableRef<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeVar : VariableVar<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeListRef : ListVariableRef<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.RayTracingMode))]
	public sealed partial class RayTracingModeListVar : ListVariableVar<UnityEngine.Experimental.Rendering.RayTracingMode>
	{
	}
}
