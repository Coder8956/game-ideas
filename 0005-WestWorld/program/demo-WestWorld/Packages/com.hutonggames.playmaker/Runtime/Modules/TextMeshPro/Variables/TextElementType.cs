
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeVariable : Variable<TMPro.TextElementType>
	{
		
		public TextElementTypeVariable()
		{
		}
		
		public TextElementTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeListVariable : ListVariable<TMPro.TextElementType>
	{
		
		public TextElementTypeListVariable()
		{
		}
		
		public TextElementTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeRef : VariableRef<TMPro.TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeVar : VariableVar<TMPro.TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeListRef : ListVariableRef<TMPro.TextElementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextElementType))]
	public sealed partial class TextElementTypeListVar : ListVariableVar<TMPro.TextElementType>
	{
	}
}
