
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextVariable : Variable<UnityEngine.WSA.TileForegroundText>
	{
		
		public TileForegroundTextVariable()
		{
		}
		
		public TileForegroundTextVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextListVariable : ListVariable<UnityEngine.WSA.TileForegroundText>
	{
		
		public TileForegroundTextListVariable()
		{
		}
		
		public TileForegroundTextListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextRef : VariableRef<UnityEngine.WSA.TileForegroundText>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextVar : VariableVar<UnityEngine.WSA.TileForegroundText>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextListRef : ListVariableRef<UnityEngine.WSA.TileForegroundText>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileForegroundText))]
	public sealed partial class TileForegroundTextListVar : ListVariableVar<UnityEngine.WSA.TileForegroundText>
	{
	}
}
