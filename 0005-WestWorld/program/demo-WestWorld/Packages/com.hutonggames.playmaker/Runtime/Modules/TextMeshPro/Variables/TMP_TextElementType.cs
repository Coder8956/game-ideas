
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeVariable : Variable<TMPro.TMP_TextElementType>
	{
		
		public TMP_TextElementTypeVariable()
		{
		}
		
		public TMP_TextElementTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeListVariable : ListVariable<TMPro.TMP_TextElementType>
	{
		
		public TMP_TextElementTypeListVariable()
		{
		}
		
		public TMP_TextElementTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeRef : VariableRef<TMPro.TMP_TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeVar : VariableVar<TMPro.TMP_TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeListRef : ListVariableRef<TMPro.TMP_TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElementType))]
	public sealed partial class TMP_TextElementTypeListVar : ListVariableVar<TMPro.TMP_TextElementType>
	{
	}
}
