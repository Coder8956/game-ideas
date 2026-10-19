
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeVariable : Variable<UnityEngine.Rendering.GraphicsDeviceType>
	{
		
		public GraphicsDeviceTypeVariable()
		{
		}
		
		public GraphicsDeviceTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeListVariable : ListVariable<UnityEngine.Rendering.GraphicsDeviceType>
	{
		
		public GraphicsDeviceTypeListVariable()
		{
		}
		
		public GraphicsDeviceTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeRef : VariableRef<UnityEngine.Rendering.GraphicsDeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeVar : VariableVar<UnityEngine.Rendering.GraphicsDeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeListRef : ListVariableRef<UnityEngine.Rendering.GraphicsDeviceType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.GraphicsDeviceType))]
	public sealed partial class GraphicsDeviceTypeListVar : ListVariableVar<UnityEngine.Rendering.GraphicsDeviceType>
	{
	}
}
