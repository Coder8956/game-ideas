
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoVariable : Variable<TMPro.TMP_PageInfo>
	{
		
		public TMP_PageInfoVariable()
		{
		}
		
		public TMP_PageInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoListVariable : ListVariable<TMPro.TMP_PageInfo>
	{
		
		public TMP_PageInfoListVariable()
		{
		}
		
		public TMP_PageInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoRef : VariableRef<TMPro.TMP_PageInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoVar : VariableVar<TMPro.TMP_PageInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoListRef : ListVariableRef<TMPro.TMP_PageInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_PageInfo))]
	public sealed partial class TMP_PageInfoListVar : ListVariableVar<TMPro.TMP_PageInfo>
	{
	}
}
