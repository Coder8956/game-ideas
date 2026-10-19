
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventVariable : Variable<UnityEngine.UI.Dropdown.DropdownEvent>
	{
		
		public Dropdown_DropdownEventVariable()
		{
		}
		
		public Dropdown_DropdownEventVariable(string name) : 
				base(name)
		{
		}
	}

	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventRef : VariableRef<UnityEngine.UI.Dropdown.DropdownEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventVar : VariableVar<UnityEngine.UI.Dropdown.DropdownEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventListVariable : ListVariable<UnityEngine.UI.Dropdown.DropdownEvent>
	{
		
		public Dropdown_DropdownEventListVariable()
		{
		}
		
		public Dropdown_DropdownEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventListRef : ListVariableRef<UnityEngine.UI.Dropdown.DropdownEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.DropdownEvent))]
	public sealed partial class Dropdown_DropdownEventListVar : ListVariableVar<UnityEngine.UI.Dropdown.DropdownEvent>
	{
	}
	*/
}
