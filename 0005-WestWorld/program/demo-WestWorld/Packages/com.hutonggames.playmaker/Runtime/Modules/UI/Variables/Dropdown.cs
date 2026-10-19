
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownVariable : Variable<UnityEngine.UI.Dropdown>
	{
		
		public DropdownVariable()
		{
		}
		
		public DropdownVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownListVariable : ListVariable<UnityEngine.UI.Dropdown>
	{
		
		public DropdownListVariable()
		{
		}
		
		public DropdownListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownRef : BaseComponentRef<UnityEngine.UI.Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownVar : BaseComponentVar<UnityEngine.UI.Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownListRef : ListVariableRef<UnityEngine.UI.Dropdown>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown))]
	public sealed partial class DropdownListVar : ListVariableVar<UnityEngine.UI.Dropdown>
	{
	}
}
