
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeVariable : Variable<UnityEngine.TransparencySortMode>
	{
		
		public TransparencySortModeVariable()
		{
		}
		
		public TransparencySortModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeListVariable : ListVariable<UnityEngine.TransparencySortMode>
	{
		
		public TransparencySortModeListVariable()
		{
		}
		
		public TransparencySortModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeRef : VariableRef<UnityEngine.TransparencySortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeVar : VariableVar<UnityEngine.TransparencySortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeListRef : ListVariableRef<UnityEngine.TransparencySortMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TransparencySortMode))]
	public sealed partial class TransparencySortModeListVar : ListVariableVar<UnityEngine.TransparencySortMode>
	{
	}
}
