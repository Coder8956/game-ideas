
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoVariable : Variable<TMPro.TMP_LineInfo>
	{
		
		public TMP_LineInfoVariable()
		{
		}
		
		public TMP_LineInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoListVariable : ListVariable<TMPro.TMP_LineInfo>
	{
		
		public TMP_LineInfoListVariable()
		{
		}
		
		public TMP_LineInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoRef : VariableRef<TMPro.TMP_LineInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoVar : VariableVar<TMPro.TMP_LineInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoListRef : ListVariableRef<TMPro.TMP_LineInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_LineInfo))]
	public sealed partial class TMP_LineInfoListVar : ListVariableVar<TMPro.TMP_LineInfo>
	{
	}
}
