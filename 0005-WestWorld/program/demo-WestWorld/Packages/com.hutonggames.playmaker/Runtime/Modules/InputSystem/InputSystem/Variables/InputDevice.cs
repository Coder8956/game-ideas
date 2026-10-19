#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceVariable : Variable<UnityEngine.InputSystem.InputDevice>
	{
		
		public InputDeviceVariable()
		{
		}
		
		public InputDeviceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceListVariable : ListVariable<UnityEngine.InputSystem.InputDevice>
	{
		
		public InputDeviceListVariable()
		{
		}
		
		public InputDeviceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceRef : VariableRef<UnityEngine.InputSystem.InputDevice>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceVar : VariableVar<UnityEngine.InputSystem.InputDevice>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceListRef : ListVariableRef<UnityEngine.InputSystem.InputDevice>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceListVar : ListVariableVar<UnityEngine.InputSystem.InputDevice>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceOverride : VariableOverride<UnityEngine.InputSystem.InputDevice, InputDeviceVariable, InputDeviceVar>
	{
		public InputDeviceOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceOutput : VariableOutput<UnityEngine.InputSystem.InputDevice, InputDeviceVariable, InputDeviceRef>
	{
		public InputDeviceOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceListOverride : VariableOverride<List<UnityEngine.InputSystem.InputDevice>, InputDeviceListVariable, InputDeviceListVar>
	{
		public InputDeviceListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputDevice))]
	public sealed partial class InputDeviceListOutput : VariableOutput<List<UnityEngine.InputSystem.InputDevice>, InputDeviceListVariable, InputDeviceListRef>
	{
		public InputDeviceListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
#endif
