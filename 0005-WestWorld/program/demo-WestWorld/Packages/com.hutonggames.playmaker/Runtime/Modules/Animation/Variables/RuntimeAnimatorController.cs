
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerVariable : Variable<UnityEngine.RuntimeAnimatorController>
	{
		
		public RuntimeAnimatorControllerVariable()
		{
		}
		
		public RuntimeAnimatorControllerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerListVariable : ListVariable<UnityEngine.RuntimeAnimatorController>
	{
		
		public RuntimeAnimatorControllerListVariable()
		{
		}
		
		public RuntimeAnimatorControllerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerRef : VariableRef<UnityEngine.RuntimeAnimatorController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerVar : VariableVar<UnityEngine.RuntimeAnimatorController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerListRef : ListVariableRef<UnityEngine.RuntimeAnimatorController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RuntimeAnimatorController))]
	public sealed partial class RuntimeAnimatorControllerListVar : ListVariableVar<UnityEngine.RuntimeAnimatorController>
	{
	}
}
