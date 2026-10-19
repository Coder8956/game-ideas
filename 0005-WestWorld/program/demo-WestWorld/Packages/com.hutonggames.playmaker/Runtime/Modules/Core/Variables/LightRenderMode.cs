
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeVariable : Variable<UnityEngine.LightRenderMode>
	{
		
		public LightRenderModeVariable()
		{
		}
		
		public LightRenderModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeListVariable : ListVariable<UnityEngine.LightRenderMode>
	{
		
		public LightRenderModeListVariable()
		{
		}
		
		public LightRenderModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeRef : VariableRef<UnityEngine.LightRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeVar : VariableVar<UnityEngine.LightRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeListRef : ListVariableRef<UnityEngine.LightRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightRenderMode))]
	public sealed partial class LightRenderModeListVar : ListVariableVar<UnityEngine.LightRenderMode>
	{
	}
}
