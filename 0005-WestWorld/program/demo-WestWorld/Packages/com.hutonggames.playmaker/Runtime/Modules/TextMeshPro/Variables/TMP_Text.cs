
using System;
using TMPro;

// ReSharper disable PartialTypeWithSinglePart

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextVariable : Variable<TMP_Text>
	{
		
		public TMP_TextVariable()
		{
		}
		
		public TMP_TextVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextListVariable : ListVariable<TMP_Text>
	{
		
		public TMP_TextListVariable()
		{
		}
		
		public TMP_TextListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextRef : VariableRef<TMP_Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextVar : VariableVar<TMP_Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextListRef : ListVariableRef<TMP_Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextListVar : ListVariableVar<TMP_Text>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextOverride : VariableOverride<TMP_Text,TMP_TextVariable,TMP_TextVar>
	{
		
		public TMP_TextOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMP_Text))]
	public sealed partial class TMP_TextOutput : VariableOutput<TMP_Text,TMP_TextVariable,TMP_TextRef>
	{
		
		public TMP_TextOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
