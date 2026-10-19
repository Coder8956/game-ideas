
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleVariable : Variable<UnityEngine.FontStyle>
	{
		
		public FontStyleVariable()
		{
		}
		
		public FontStyleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleListVariable : ListVariable<UnityEngine.FontStyle>
	{
		
		public FontStyleListVariable()
		{
		}
		
		public FontStyleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleRef : VariableRef<UnityEngine.FontStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleVar : VariableVar<UnityEngine.FontStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleListRef : ListVariableRef<UnityEngine.FontStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FontStyle))]
	public sealed partial class FontStyleListVar : ListVariableVar<UnityEngine.FontStyle>
	{
	}
}
