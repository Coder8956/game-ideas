
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererVariable : Variable<UnityEngine.Renderer>
	{
		
		public RendererVariable()
		{
		}
		
		public RendererVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererListVariable : ListVariable<UnityEngine.Renderer>
	{
		
		public RendererListVariable()
		{
		}
		
		public RendererListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererRef : BaseComponentRef<UnityEngine.Renderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererVar : BaseComponentVar<UnityEngine.Renderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererListRef : ListVariableRef<UnityEngine.Renderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Renderer))]
	public sealed partial class RendererListVar : ListVariableVar<UnityEngine.Renderer>
	{
	}
}
