
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesVariable : Variable<TMPro.TextOverflowModes>
	{
		
		public TextOverflowModesVariable()
		{
		}
		
		public TextOverflowModesVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesListVariable : ListVariable<TMPro.TextOverflowModes>
	{
		
		public TextOverflowModesListVariable()
		{
		}
		
		public TextOverflowModesListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesRef : VariableRef<TMPro.TextOverflowModes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesVar : VariableVar<TMPro.TextOverflowModes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesListRef : ListVariableRef<TMPro.TextOverflowModes>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TextOverflowModes))]
	public sealed partial class TextOverflowModesListVar : ListVariableVar<TMPro.TextOverflowModes>
	{
	}
}
