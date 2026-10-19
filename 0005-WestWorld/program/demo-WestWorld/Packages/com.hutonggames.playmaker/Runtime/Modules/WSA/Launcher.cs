
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherVariable : Variable<UnityEngine.WSA.Launcher>
	{
		
		public LauncherVariable()
		{
		}
		
		public LauncherVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherListVariable : ListVariable<UnityEngine.WSA.Launcher>
	{
		
		public LauncherListVariable()
		{
		}
		
		public LauncherListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherRef : VariableRef<UnityEngine.WSA.Launcher>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherVar : VariableVar<UnityEngine.WSA.Launcher>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherListRef : ListVariableRef<UnityEngine.WSA.Launcher>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.Launcher))]
	public sealed partial class LauncherListVar : ListVariableVar<UnityEngine.WSA.Launcher>
	{
	}
}
