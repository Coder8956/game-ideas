
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeVariable : Variable<UnityEngine.KeyCode>
	{
		
		public KeyCodeVariable()
		{
		}
		
		public KeyCodeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeListVariable : ListVariable<UnityEngine.KeyCode>
	{
		
		public KeyCodeListVariable()
		{
		}
		
		public KeyCodeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeRef : VariableRef<UnityEngine.KeyCode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeVar : VariableVar<UnityEngine.KeyCode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeListRef : ListVariableRef<UnityEngine.KeyCode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.KeyCode))]
	public sealed partial class KeyCodeListVar : ListVariableVar<UnityEngine.KeyCode>
	{
	}
}
