
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventVariable : Variable<TMPro.TMP_Dropdown.DropdownEvent>
	{
		
		public TMP_Dropdown_DropdownEventVariable()
		{
		}
		
		public TMP_Dropdown_DropdownEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventRef : VariableRef<TMPro.TMP_Dropdown.DropdownEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventVar : VariableVar<TMPro.TMP_Dropdown.DropdownEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventListVariable : ListVariable<TMPro.TMP_Dropdown.DropdownEvent>
	{
		
		public TMP_Dropdown_DropdownEventListVariable()
		{
		}
		
		public TMP_Dropdown_DropdownEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventListRef : ListVariableRef<TMPro.TMP_Dropdown.DropdownEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_Dropdown.DropdownEvent))]
	public sealed partial class TMP_Dropdown_DropdownEventListVar : ListVariableVar<TMPro.TMP_Dropdown.DropdownEvent>
	{
	}
	*/
}
