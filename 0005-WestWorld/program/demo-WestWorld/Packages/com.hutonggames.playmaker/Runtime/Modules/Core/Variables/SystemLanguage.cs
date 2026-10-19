
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageVariable : Variable<UnityEngine.SystemLanguage>
	{
		
		public SystemLanguageVariable()
		{
		}
		
		public SystemLanguageVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageListVariable : ListVariable<UnityEngine.SystemLanguage>
	{
		
		public SystemLanguageListVariable()
		{
		}
		
		public SystemLanguageListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageRef : VariableRef<UnityEngine.SystemLanguage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageVar : VariableVar<UnityEngine.SystemLanguage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageListRef : ListVariableRef<UnityEngine.SystemLanguage>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SystemLanguage))]
	public sealed partial class SystemLanguageListVar : ListVariableVar<UnityEngine.SystemLanguage>
	{
	}
}
