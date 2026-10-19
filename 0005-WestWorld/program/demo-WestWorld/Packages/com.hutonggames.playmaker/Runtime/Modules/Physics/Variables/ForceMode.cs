
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeVariable : Variable<UnityEngine.ForceMode>
	{
		
		public ForceModeVariable()
		{
		}
		
		public ForceModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeListVariable : ListVariable<UnityEngine.ForceMode>
	{
		
		public ForceModeListVariable()
		{
		}
		
		public ForceModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeRef : VariableRef<UnityEngine.ForceMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeVar : VariableVar<UnityEngine.ForceMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeListRef : ListVariableRef<UnityEngine.ForceMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode))]
	public sealed partial class ForceModeListVar : ListVariableVar<UnityEngine.ForceMode>
	{
	}
}
