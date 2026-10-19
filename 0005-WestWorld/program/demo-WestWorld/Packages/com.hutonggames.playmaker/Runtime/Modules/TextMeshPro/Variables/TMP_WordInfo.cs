
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoVariable : Variable<TMPro.TMP_WordInfo>
	{
		
		public TMP_WordInfoVariable()
		{
		}
		
		public TMP_WordInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoListVariable : ListVariable<TMPro.TMP_WordInfo>
	{
		
		public TMP_WordInfoListVariable()
		{
		}
		
		public TMP_WordInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoRef : VariableRef<TMPro.TMP_WordInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoVar : VariableVar<TMPro.TMP_WordInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoListRef : ListVariableRef<TMPro.TMP_WordInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_WordInfo))]
	public sealed partial class TMP_WordInfoListVar : ListVariableVar<TMPro.TMP_WordInfo>
	{
	}
}
