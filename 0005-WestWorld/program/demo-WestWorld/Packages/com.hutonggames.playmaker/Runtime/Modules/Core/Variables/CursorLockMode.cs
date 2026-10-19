
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeVariable : Variable<UnityEngine.CursorLockMode>
	{
		
		public CursorLockModeVariable()
		{
		}
		
		public CursorLockModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeListVariable : ListVariable<UnityEngine.CursorLockMode>
	{
		
		public CursorLockModeListVariable()
		{
		}
		
		public CursorLockModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeRef : VariableRef<UnityEngine.CursorLockMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeVar : VariableVar<UnityEngine.CursorLockMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeListRef : ListVariableRef<UnityEngine.CursorLockMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CursorLockMode))]
	public sealed partial class CursorLockModeListVar : ListVariableVar<UnityEngine.CursorLockMode>
	{
	}
}
