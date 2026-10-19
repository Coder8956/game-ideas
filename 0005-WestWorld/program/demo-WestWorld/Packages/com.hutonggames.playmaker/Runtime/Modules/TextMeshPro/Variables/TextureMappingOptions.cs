
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsVariable : Variable<TMPro.TextureMappingOptions>
	{
		
		public TextureMappingOptionsVariable()
		{
		}
		
		public TextureMappingOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsListVariable : ListVariable<TMPro.TextureMappingOptions>
	{
		
		public TextureMappingOptionsListVariable()
		{
		}
		
		public TextureMappingOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsRef : VariableRef<TMPro.TextureMappingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsVar : VariableVar<TMPro.TextureMappingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsListRef : ListVariableRef<TMPro.TextureMappingOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextureMappingOptions))]
	public sealed partial class TextureMappingOptionsListVar : ListVariableVar<TMPro.TextureMappingOptions>
	{
	}
}
