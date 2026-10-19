
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataVariable : Variable<TMPro.TMP_Dropdown.OptionData>
	{
		
		public TMP_Dropdown_OptionDataVariable()
		{
		}
		
		public TMP_Dropdown_OptionDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataListVariable : ListVariable<TMPro.TMP_Dropdown.OptionData>
	{
		
		public TMP_Dropdown_OptionDataListVariable()
		{
		}
		
		public TMP_Dropdown_OptionDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataRef : VariableRef<TMPro.TMP_Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataVar : VariableVar<TMPro.TMP_Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataListRef : ListVariableRef<TMPro.TMP_Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.OptionData))]
	public sealed partial class TMP_Dropdown_OptionDataListVar : ListVariableVar<TMPro.TMP_Dropdown.OptionData>
	{
	}
}
