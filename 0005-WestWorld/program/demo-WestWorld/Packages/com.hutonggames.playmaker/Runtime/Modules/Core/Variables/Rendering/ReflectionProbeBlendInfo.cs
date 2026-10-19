
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoVariable : Variable<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
		
		public ReflectionProbeBlendInfoVariable()
		{
		}
		
		public ReflectionProbeBlendInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoListVariable : ListVariable<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
		
		public ReflectionProbeBlendInfoListVariable()
		{
		}
		
		public ReflectionProbeBlendInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoRef : VariableRef<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoVar : VariableVar<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoListRef : ListVariableRef<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo))]
	public sealed partial class ReflectionProbeBlendInfoListVar : ListVariableVar<UnityEngine.Rendering.ReflectionProbeBlendInfo>
	{
	}
}
