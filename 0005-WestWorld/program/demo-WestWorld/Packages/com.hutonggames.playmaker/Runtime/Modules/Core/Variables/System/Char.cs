
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharVariable : Variable<System.Char>
	{
		
		public CharVariable()
		{
		}
		
		public CharVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharListVariable : ListVariable<System.Char>
	{
		
		public CharListVariable()
		{
		}
		
		public CharListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharRef : VariableRef<System.Char>
	{
	}
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharVar : VariableVar<System.Char>
	{
	}
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharListRef : ListVariableRef<System.Char>
	{
	}
	
	[Serializable]
	[DataType(typeof(char))]
	public sealed partial class CharListVar : ListVariableVar<System.Char>
	{
	}
}
