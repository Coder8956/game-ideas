
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoVariable : Variable<TMPro.TMP_LinkInfo>
	{
		
		public TMP_LinkInfoVariable()
		{
		}
		
		public TMP_LinkInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoListVariable : ListVariable<TMPro.TMP_LinkInfo>
	{
		
		public TMP_LinkInfoListVariable()
		{
		}
		
		public TMP_LinkInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoRef : VariableRef<TMPro.TMP_LinkInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoVar : VariableVar<TMPro.TMP_LinkInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoListRef : ListVariableRef<TMPro.TMP_LinkInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LinkInfo))]
	public sealed partial class TMP_LinkInfoListVar : ListVariableVar<TMPro.TMP_LinkInfo>
	{
	}
}
