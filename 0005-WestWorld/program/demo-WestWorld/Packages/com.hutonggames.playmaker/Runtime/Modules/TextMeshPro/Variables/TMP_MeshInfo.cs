
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoVariable : Variable<TMPro.TMP_MeshInfo>
	{
		
		public TMP_MeshInfoVariable()
		{
		}
		
		public TMP_MeshInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoListVariable : ListVariable<TMPro.TMP_MeshInfo>
	{
		
		public TMP_MeshInfoListVariable()
		{
		}
		
		public TMP_MeshInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoRef : VariableRef<TMPro.TMP_MeshInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoVar : VariableVar<TMPro.TMP_MeshInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoListRef : ListVariableRef<TMPro.TMP_MeshInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_MeshInfo))]
	public sealed partial class TMP_MeshInfoListVar : ListVariableVar<TMPro.TMP_MeshInfo>
	{
	}
}
