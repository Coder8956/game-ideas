
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessVariable : Variable<UnityEngine.RenderTextureMemoryless>
	{
		
		public RenderTextureMemorylessVariable()
		{
		}
		
		public RenderTextureMemorylessVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessListVariable : ListVariable<UnityEngine.RenderTextureMemoryless>
	{
		
		public RenderTextureMemorylessListVariable()
		{
		}
		
		public RenderTextureMemorylessListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessRef : VariableRef<UnityEngine.RenderTextureMemoryless>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessVar : VariableVar<UnityEngine.RenderTextureMemoryless>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessListRef : ListVariableRef<UnityEngine.RenderTextureMemoryless>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderTextureMemoryless))]
	public sealed partial class RenderTextureMemorylessListVar : ListVariableVar<UnityEngine.RenderTextureMemoryless>
	{
	}
}
