
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownVariable : Variable<TMPro.TMP_Dropdown>
	{
		
		public TMP_DropdownVariable()
		{
		}
		
		public TMP_DropdownVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownListVariable : ListVariable<TMPro.TMP_Dropdown>
	{
		
		public TMP_DropdownListVariable()
		{
		}
		
		public TMP_DropdownListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownRef : BaseComponentRef<TMPro.TMP_Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownVar : BaseComponentVar<TMPro.TMP_Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownListRef : ListVariableRef<TMPro.TMP_Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown))]
	public sealed partial class TMP_DropdownListVar : ListVariableVar<TMPro.TMP_Dropdown>
	{
	}
}
