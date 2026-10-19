
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoVariable : Variable<TMPro.TMP_TextInfo>
	{
		
		public TMP_TextInfoVariable()
		{
		}
		
		public TMP_TextInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoListVariable : ListVariable<TMPro.TMP_TextInfo>
	{
		
		public TMP_TextInfoListVariable()
		{
		}
		
		public TMP_TextInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoRef : VariableRef<TMPro.TMP_TextInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoVar : VariableVar<TMPro.TMP_TextInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoListRef : ListVariableRef<TMPro.TMP_TextInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextInfo))]
	public sealed partial class TMP_TextInfoListVar : ListVariableVar<TMPro.TMP_TextInfo>
	{
	}
}
