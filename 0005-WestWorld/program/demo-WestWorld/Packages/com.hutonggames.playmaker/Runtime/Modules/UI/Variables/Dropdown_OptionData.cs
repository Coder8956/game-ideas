
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataVariable : Variable<UnityEngine.UI.Dropdown.OptionData>
	{
		
		public Dropdown_OptionDataVariable()
		{
		}
		
		public Dropdown_OptionDataVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataListVariable : ListVariable<UnityEngine.UI.Dropdown.OptionData>
	{
		
		public Dropdown_OptionDataListVariable()
		{
		}
		
		public Dropdown_OptionDataListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataRef : VariableRef<UnityEngine.UI.Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataVar : VariableVar<UnityEngine.UI.Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataListRef : ListVariableRef<UnityEngine.UI.Dropdown.OptionData>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Dropdown.OptionData))]
	public sealed partial class Dropdown_OptionDataListVar : ListVariableVar<UnityEngine.UI.Dropdown.OptionData>
	{
	}
}
