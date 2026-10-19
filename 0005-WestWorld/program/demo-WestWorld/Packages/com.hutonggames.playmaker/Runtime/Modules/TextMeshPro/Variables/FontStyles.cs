
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesVariable : Variable<TMPro.FontStyles>
	{
		
		public FontStylesVariable()
		{
		}
		
		public FontStylesVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesListVariable : ListVariable<TMPro.FontStyles>
	{
		
		public FontStylesListVariable()
		{
		}
		
		public FontStylesListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesRef : VariableRef<TMPro.FontStyles>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesVar : VariableVar<TMPro.FontStyles>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesListRef : ListVariableRef<TMPro.FontStyles>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontStyles))]
	public sealed partial class FontStylesListVar : ListVariableVar<TMPro.FontStyles>
	{
	}
}
