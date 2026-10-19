
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionVariable : Variable<UnityEngine.Rendering.LightShadowResolution>
	{
		
		public LightShadowResolutionVariable()
		{
		}
		
		public LightShadowResolutionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionListVariable : ListVariable<UnityEngine.Rendering.LightShadowResolution>
	{
		
		public LightShadowResolutionListVariable()
		{
		}
		
		public LightShadowResolutionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionRef : VariableRef<UnityEngine.Rendering.LightShadowResolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionVar : VariableVar<UnityEngine.Rendering.LightShadowResolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionListRef : ListVariableRef<UnityEngine.Rendering.LightShadowResolution>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.LightShadowResolution))]
	public sealed partial class LightShadowResolutionListVar : ListVariableVar<UnityEngine.Rendering.LightShadowResolution>
	{
	}
}
