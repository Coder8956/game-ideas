
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatVariable : Variable<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
		
		public GraphicsFormatVariable()
		{
		}
		
		public GraphicsFormatVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatListVariable : ListVariable<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
		
		public GraphicsFormatListVariable()
		{
		}
		
		public GraphicsFormatListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatRef : VariableRef<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatVar : VariableVar<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatListRef : ListVariableRef<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))]
	public sealed partial class GraphicsFormatListVar : ListVariableVar<UnityEngine.Experimental.Rendering.GraphicsFormat>
	{
	}
}
