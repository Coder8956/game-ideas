
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateVariable : Variable<UnityEngine.WSA.WindowActivationState>
	{
		
		public WindowActivationStateVariable()
		{
		}
		
		public WindowActivationStateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateListVariable : ListVariable<UnityEngine.WSA.WindowActivationState>
	{
		
		public WindowActivationStateListVariable()
		{
		}
		
		public WindowActivationStateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateRef : VariableRef<UnityEngine.WSA.WindowActivationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateVar : VariableVar<UnityEngine.WSA.WindowActivationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateListRef : ListVariableRef<UnityEngine.WSA.WindowActivationState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.WindowActivationState))]
	public sealed partial class WindowActivationStateListVar : ListVariableVar<UnityEngine.WSA.WindowActivationState>
	{
	}
}
