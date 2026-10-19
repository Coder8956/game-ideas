
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementVariable : Variable<TMPro.TMP_TextElement>
	{
		
		public TMP_TextElementVariable()
		{
		}
		
		public TMP_TextElementVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementListVariable : ListVariable<TMPro.TMP_TextElement>
	{
		
		public TMP_TextElementListVariable()
		{
		}
		
		public TMP_TextElementListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementRef : VariableRef<TMPro.TMP_TextElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementVar : VariableVar<TMPro.TMP_TextElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementListRef : ListVariableRef<TMPro.TMP_TextElement>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_TextElement))]
	public sealed partial class TMP_TextElementListVar : ListVariableVar<TMPro.TMP_TextElement>
	{
	}
}
