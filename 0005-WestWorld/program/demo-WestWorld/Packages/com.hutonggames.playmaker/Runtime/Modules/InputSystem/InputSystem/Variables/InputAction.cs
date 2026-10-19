#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionVariable : Variable<UnityEngine.InputSystem.InputAction>
	{
		
		public InputActionVariable()
		{
		}
		
		public InputActionVariable(string name) : 
				base(name)
		{
		}

		public override bool CanConvertTo(Type otherType)
		{
			return otherType == typeof(InputActionProperty);
		}
		
		public override TAsType GetValue<TAsType>()
		{
			if (typeof(TAsType) == typeof(InputActionProperty))
				return (TAsType)(object)new InputActionProperty(_value);
            
			return base.GetValue<TAsType>();
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionListVariable : ListVariable<UnityEngine.InputSystem.InputAction>
	{
		
		public InputActionListVariable()
		{
		}
		
		public InputActionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionRef : VariableRef<UnityEngine.InputSystem.InputAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionVar : VariableVar<UnityEngine.InputSystem.InputAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionListRef : ListVariableRef<UnityEngine.InputSystem.InputAction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionListVar : ListVariableVar<UnityEngine.InputSystem.InputAction>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionOverride : VariableOverride<UnityEngine.InputSystem.InputAction, InputActionVariable, InputActionVar>
	{
		public InputActionOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionOutput : VariableOutput<UnityEngine.InputSystem.InputAction, InputActionVariable, InputActionRef>
	{
		public InputActionOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionListOverride : VariableOverride<List<UnityEngine.InputSystem.InputAction>, InputActionListVariable, InputActionListVar>
	{
		public InputActionListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputAction))]
	public sealed partial class InputActionListOutput : VariableOutput<List<UnityEngine.InputSystem.InputAction>, InputActionListVariable, InputActionListRef>
	{
		public InputActionListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
#endif
