
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeVariable : Variable<UnityEngine.FilterMode>
	{
		
		public FilterModeVariable()
		{
		}
		
		public FilterModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeListVariable : ListVariable<UnityEngine.FilterMode>
	{
		
		public FilterModeListVariable()
		{
		}
		
		public FilterModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeRef : VariableRef<UnityEngine.FilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeVar : VariableVar<UnityEngine.FilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeListRef : ListVariableRef<UnityEngine.FilterMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FilterMode))]
	public sealed partial class FilterModeListVar : ListVariableVar<UnityEngine.FilterMode>
	{
	}
}
