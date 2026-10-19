
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeVariable : Variable<UnityEngine.Rendering.RenderingThreadingMode>
	{
		
		public RenderingThreadingModeVariable()
		{
		}
		
		public RenderingThreadingModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeListVariable : ListVariable<UnityEngine.Rendering.RenderingThreadingMode>
	{
		
		public RenderingThreadingModeListVariable()
		{
		}
		
		public RenderingThreadingModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeRef : VariableRef<UnityEngine.Rendering.RenderingThreadingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeVar : VariableVar<UnityEngine.Rendering.RenderingThreadingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeListRef : ListVariableRef<UnityEngine.Rendering.RenderingThreadingMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.RenderingThreadingMode))]
	public sealed partial class RenderingThreadingModeListVar : ListVariableVar<UnityEngine.Rendering.RenderingThreadingMode>
	{
	}
}
