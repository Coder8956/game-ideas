
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererVariable : Variable<UnityEngine.CanvasRenderer>
	{
		
		public CanvasRendererVariable()
		{
		}
		
		public CanvasRendererVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererListVariable : ListVariable<UnityEngine.CanvasRenderer>
	{
		
		public CanvasRendererListVariable()
		{
		}
		
		public CanvasRendererListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererRef : BaseComponentRef<UnityEngine.CanvasRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererVar : BaseComponentVar<UnityEngine.CanvasRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererListRef : ListVariableRef<UnityEngine.CanvasRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasRenderer))]
	public sealed partial class CanvasRendererListVar : ListVariableVar<UnityEngine.CanvasRenderer>
	{
	}
}
