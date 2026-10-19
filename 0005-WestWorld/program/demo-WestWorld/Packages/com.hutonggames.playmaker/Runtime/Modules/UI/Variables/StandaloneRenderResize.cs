
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeVariable : Variable<UnityEngine.StandaloneRenderResize>
	{
		
		public StandaloneRenderResizeVariable()
		{
		}
		
		public StandaloneRenderResizeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeListVariable : ListVariable<UnityEngine.StandaloneRenderResize>
	{
		
		public StandaloneRenderResizeListVariable()
		{
		}
		
		public StandaloneRenderResizeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeRef : VariableRef<UnityEngine.StandaloneRenderResize>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeVar : VariableVar<UnityEngine.StandaloneRenderResize>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeListRef : ListVariableRef<UnityEngine.StandaloneRenderResize>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.StandaloneRenderResize))]
	public sealed partial class StandaloneRenderResizeListVar : ListVariableVar<UnityEngine.StandaloneRenderResize>
	{
	}
}
