#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceVariable : Variable<UnityEngine.InputSystem.InputActionReference>
	{
		
		public InputActionReferenceVariable()
		{
		}
		
		public InputActionReferenceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceListVariable : ListVariable<UnityEngine.InputSystem.InputActionReference>
	{
		
		public InputActionReferenceListVariable()
		{
		}
		
		public InputActionReferenceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceRef : VariableRef<UnityEngine.InputSystem.InputActionReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceVar : VariableVar<UnityEngine.InputSystem.InputActionReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceListRef : ListVariableRef<UnityEngine.InputSystem.InputActionReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceListVar : ListVariableVar<UnityEngine.InputSystem.InputActionReference>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceOverride : VariableOverride<UnityEngine.InputSystem.InputActionReference, InputActionReferenceVariable, InputActionReferenceVar>
	{
		public InputActionReferenceOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceOutput : VariableOutput<UnityEngine.InputSystem.InputActionReference, InputActionReferenceVariable, InputActionReferenceRef>
	{
		public InputActionReferenceOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceListOverride : VariableOverride<List<UnityEngine.InputSystem.InputActionReference>, InputActionReferenceListVariable, InputActionReferenceListVar>
	{
		public InputActionReferenceListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionReference))]
	public sealed partial class InputActionReferenceListOutput : VariableOutput<List<UnityEngine.InputSystem.InputActionReference>, InputActionReferenceListVariable, InputActionReferenceListRef>
	{
		public InputActionReferenceListOutput(IVariable variable) : base(variable)
		{
		}
	}
}

#endif
