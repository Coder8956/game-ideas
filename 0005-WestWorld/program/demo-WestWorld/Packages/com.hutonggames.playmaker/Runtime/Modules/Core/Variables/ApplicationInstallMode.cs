
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeVariable : Variable<UnityEngine.ApplicationInstallMode>
	{
		
		public ApplicationInstallModeVariable()
		{
		}
		
		public ApplicationInstallModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeListVariable : ListVariable<UnityEngine.ApplicationInstallMode>
	{
		
		public ApplicationInstallModeListVariable()
		{
		}
		
		public ApplicationInstallModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeRef : VariableRef<UnityEngine.ApplicationInstallMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeVar : VariableVar<UnityEngine.ApplicationInstallMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeListRef : ListVariableRef<UnityEngine.ApplicationInstallMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ApplicationInstallMode))]
	public sealed partial class ApplicationInstallModeListVar : ListVariableVar<UnityEngine.ApplicationInstallMode>
	{
	}
}
