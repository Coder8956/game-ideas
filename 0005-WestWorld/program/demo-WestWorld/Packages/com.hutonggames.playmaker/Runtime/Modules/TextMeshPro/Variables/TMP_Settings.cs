
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsVariable : Variable<TMPro.TMP_Settings>
	{
		
		public TMP_SettingsVariable()
		{
		}
		
		public TMP_SettingsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsListVariable : ListVariable<TMPro.TMP_Settings>
	{
		
		public TMP_SettingsListVariable()
		{
		}
		
		public TMP_SettingsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsRef : VariableRef<TMPro.TMP_Settings>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsVar : VariableVar<TMPro.TMP_Settings>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsListRef : ListVariableRef<TMPro.TMP_Settings>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Settings))]
	public sealed partial class TMP_SettingsListVar : ListVariableVar<TMPro.TMP_Settings>
	{
	}
}
