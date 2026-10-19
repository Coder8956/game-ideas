
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionVariable : Variable<UnityEngine.UI.Toggle.ToggleTransition>
	{
		
		public Toggle_ToggleTransitionVariable()
		{
		}
		
		public Toggle_ToggleTransitionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionListVariable : ListVariable<UnityEngine.UI.Toggle.ToggleTransition>
	{
		
		public Toggle_ToggleTransitionListVariable()
		{
		}
		
		public Toggle_ToggleTransitionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionRef : VariableRef<UnityEngine.UI.Toggle.ToggleTransition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionVar : VariableVar<UnityEngine.UI.Toggle.ToggleTransition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionListRef : ListVariableRef<UnityEngine.UI.Toggle.ToggleTransition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Toggle.ToggleTransition))]
	public sealed partial class Toggle_ToggleTransitionListVar : ListVariableVar<UnityEngine.UI.Toggle.ToggleTransition>
	{
	}
}
