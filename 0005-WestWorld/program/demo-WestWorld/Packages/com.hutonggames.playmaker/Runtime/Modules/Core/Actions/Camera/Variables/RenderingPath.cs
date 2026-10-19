
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathVariable : Variable<UnityEngine.RenderingPath>
	{
		
		public RenderingPathVariable()
		{
		}
		
		public RenderingPathVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathListVariable : ListVariable<UnityEngine.RenderingPath>
	{
		
		public RenderingPathListVariable()
		{
		}
		
		public RenderingPathListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathRef : VariableRef<UnityEngine.RenderingPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathVar : VariableVar<UnityEngine.RenderingPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathListRef : ListVariableRef<UnityEngine.RenderingPath>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderingPath))]
	public sealed partial class RenderingPathListVar : ListVariableVar<UnityEngine.RenderingPath>
	{
	}
}
