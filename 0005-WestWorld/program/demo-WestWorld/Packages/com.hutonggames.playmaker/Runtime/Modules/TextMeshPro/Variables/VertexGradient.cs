
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientVariable : Variable<TMPro.VertexGradient>
	{
		
		public VertexGradientVariable()
		{
		}
		
		public VertexGradientVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientListVariable : ListVariable<TMPro.VertexGradient>
	{
		
		public VertexGradientListVariable()
		{
		}
		
		public VertexGradientListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientRef : VariableRef<TMPro.VertexGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientVar : VariableVar<TMPro.VertexGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientListRef : ListVariableRef<TMPro.VertexGradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.VertexGradient))]
	public sealed partial class VertexGradientListVar : ListVariableVar<TMPro.VertexGradient>
	{
	}
}
