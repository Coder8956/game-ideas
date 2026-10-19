
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetVariable : Variable<UnityEngine.RectOffset>
	{
		
		public RectOffsetVariable()
		{
		}
		
		public RectOffsetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetListVariable : ListVariable<UnityEngine.RectOffset>
	{
		
		public RectOffsetListVariable()
		{
		}
		
		public RectOffsetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetRef : VariableRef<UnityEngine.RectOffset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetVar : VariableVar<UnityEngine.RectOffset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetListRef : ListVariableRef<UnityEngine.RectOffset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectOffset))]
	public sealed partial class RectOffsetListVar : ListVariableVar<UnityEngine.RectOffset>
	{
	}
}
