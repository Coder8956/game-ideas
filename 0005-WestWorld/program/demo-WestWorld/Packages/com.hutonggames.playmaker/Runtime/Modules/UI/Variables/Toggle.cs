
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleVariable : Variable<UnityEngine.UI.Toggle>
	{
		
		public ToggleVariable()
		{
		}
		
		public ToggleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleListVariable : ListVariable<UnityEngine.UI.Toggle>
	{
		
		public ToggleListVariable()
		{
		}
		
		public ToggleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleRef : BaseComponentRef<UnityEngine.UI.Toggle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleVar : BaseComponentVar<UnityEngine.UI.Toggle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleListRef : ListVariableRef<UnityEngine.UI.Toggle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle))]
	public sealed partial class ToggleListVar : ListVariableVar<UnityEngine.UI.Toggle>
	{
	}
}
