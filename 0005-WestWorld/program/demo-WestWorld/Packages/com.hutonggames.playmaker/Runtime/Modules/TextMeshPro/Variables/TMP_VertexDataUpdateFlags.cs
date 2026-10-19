
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsVariable : Variable<TMPro.TMP_VertexDataUpdateFlags>
	{
		
		public TMP_VertexDataUpdateFlagsVariable()
		{
		}
		
		public TMP_VertexDataUpdateFlagsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsListVariable : ListVariable<TMPro.TMP_VertexDataUpdateFlags>
	{
		
		public TMP_VertexDataUpdateFlagsListVariable()
		{
		}
		
		public TMP_VertexDataUpdateFlagsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsRef : VariableRef<TMPro.TMP_VertexDataUpdateFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsVar : VariableVar<TMPro.TMP_VertexDataUpdateFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsListRef : ListVariableRef<TMPro.TMP_VertexDataUpdateFlags>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_VertexDataUpdateFlags))]
	public sealed partial class TMP_VertexDataUpdateFlagsListVar : ListVariableVar<TMPro.TMP_VertexDataUpdateFlags>
	{
	}
}
