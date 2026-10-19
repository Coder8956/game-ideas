
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetVariable : Variable<TMPro.TMP_Offset>
	{
		
		public TMP_OffsetVariable()
		{
		}
		
		public TMP_OffsetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetListVariable : ListVariable<TMPro.TMP_Offset>
	{
		
		public TMP_OffsetListVariable()
		{
		}
		
		public TMP_OffsetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetRef : VariableRef<TMPro.TMP_Offset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetVar : VariableVar<TMPro.TMP_Offset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetListRef : ListVariableRef<TMPro.TMP_Offset>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Offset))]
	public sealed partial class TMP_OffsetListVar : ListVariableVar<TMPro.TMP_Offset>
	{
	}
}
