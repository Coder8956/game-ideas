
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightVariable : Variable<TMPro.FontWeight>
	{
		
		public FontWeightVariable()
		{
		}
		
		public FontWeightVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightListVariable : ListVariable<TMPro.FontWeight>
	{
		
		public FontWeightListVariable()
		{
		}
		
		public FontWeightListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightRef : VariableRef<TMPro.FontWeight>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightVar : VariableVar<TMPro.FontWeight>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightListRef : ListVariableRef<TMPro.FontWeight>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.FontWeight))]
	public sealed partial class FontWeightListVar : ListVariableVar<TMPro.FontWeight>
	{
	}
}
