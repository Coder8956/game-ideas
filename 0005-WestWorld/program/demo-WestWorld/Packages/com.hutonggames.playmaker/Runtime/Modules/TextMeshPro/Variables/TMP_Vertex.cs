
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexVariable : Variable<TMPro.TMP_Vertex>
	{
		
		public TMP_VertexVariable()
		{
		}
		
		public TMP_VertexVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexListVariable : ListVariable<TMPro.TMP_Vertex>
	{
		
		public TMP_VertexListVariable()
		{
		}
		
		public TMP_VertexListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexRef : VariableRef<TMPro.TMP_Vertex>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexVar : VariableVar<TMPro.TMP_Vertex>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexListRef : ListVariableRef<TMPro.TMP_Vertex>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Vertex))]
	public sealed partial class TMP_VertexListVar : ListVariableVar<TMPro.TMP_Vertex>
	{
	}
}
