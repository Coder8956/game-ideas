
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventVariable : Variable<UnityEngine.UI.Toggle.ToggleEvent>
	{
		
		public Toggle_ToggleEventVariable()
		{
		}
		
		public Toggle_ToggleEventVariable(string name) : 
				base(name)
		{
		}
	}

	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventRef : VariableRef<UnityEngine.UI.Toggle.ToggleEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventVar : VariableVar<UnityEngine.UI.Toggle.ToggleEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventListVariable : ListVariable<UnityEngine.UI.Toggle.ToggleEvent>
	{
		
		public Toggle_ToggleEventListVariable()
		{
		}
		
		public Toggle_ToggleEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventListRef : ListVariableRef<UnityEngine.UI.Toggle.ToggleEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleEvent))]
	public sealed partial class Toggle_ToggleEventListVar : ListVariableVar<UnityEngine.UI.Toggle.ToggleEvent>
	{
	}
	*/
}
