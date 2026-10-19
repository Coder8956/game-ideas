
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupVariable : Variable<UnityEngine.UI.ToggleGroup>
	{
		
		public ToggleGroupVariable()
		{
		}
		
		public ToggleGroupVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupListVariable : ListVariable<UnityEngine.UI.ToggleGroup>
	{
		
		public ToggleGroupListVariable()
		{
		}
		
		public ToggleGroupListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupRef : BaseComponentRef<UnityEngine.UI.ToggleGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupVar : BaseComponentVar<UnityEngine.UI.ToggleGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupListRef : ListVariableRef<UnityEngine.UI.ToggleGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ToggleGroup))]
	public sealed partial class ToggleGroupListVar : ListVariableVar<UnityEngine.UI.ToggleGroup>
	{
	}
}
