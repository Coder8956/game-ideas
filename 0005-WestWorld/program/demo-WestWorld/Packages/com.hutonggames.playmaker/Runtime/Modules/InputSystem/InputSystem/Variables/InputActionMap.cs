#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapVariable : Variable<UnityEngine.InputSystem.InputActionMap>
	{
		
		public InputActionMapVariable()
		{
		}
		
		public InputActionMapVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapListVariable : ListVariable<UnityEngine.InputSystem.InputActionMap>
	{
		
		public InputActionMapListVariable()
		{
		}
		
		public InputActionMapListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapRef : VariableRef<UnityEngine.InputSystem.InputActionMap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapVar : VariableVar<UnityEngine.InputSystem.InputActionMap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapListRef : ListVariableRef<UnityEngine.InputSystem.InputActionMap>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapListVar : ListVariableVar<UnityEngine.InputSystem.InputActionMap>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapOverride : VariableOverride<UnityEngine.InputSystem.InputActionMap, InputActionMapVariable, InputActionMapVar>
	{
		public InputActionMapOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapOutput : VariableOutput<UnityEngine.InputSystem.InputActionMap, InputActionMapVariable, InputActionMapRef>
	{
		public InputActionMapOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapListOverride : VariableOverride<List<UnityEngine.InputSystem.InputActionMap>, InputActionMapListVariable, InputActionMapListVar>
	{
		public InputActionMapListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionMap))]
	public sealed partial class InputActionMapListOutput : VariableOutput<List<UnityEngine.InputSystem.InputActionMap>, InputActionMapListVariable, InputActionMapListRef>
	{
		public InputActionMapListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
#endif
