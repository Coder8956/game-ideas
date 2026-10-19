#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleVariable : Variable<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
		
		public InputSystemUIInputModuleVariable()
		{
		}
		
		public InputSystemUIInputModuleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleListVariable : ListVariable<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
		
		public InputSystemUIInputModuleListVariable()
		{
		}
		
		public InputSystemUIInputModuleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleRef : VariableRef<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleVar : VariableVar<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleListRef : ListVariableRef<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleListVar : ListVariableVar<UnityEngine.InputSystem.UI.InputSystemUIInputModule>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleOverride : VariableOverride<UnityEngine.InputSystem.UI.InputSystemUIInputModule, InputSystemUIInputModuleVariable, InputSystemUIInputModuleVar>
	{
		public InputSystemUIInputModuleOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleOutput : VariableOutput<UnityEngine.InputSystem.UI.InputSystemUIInputModule, InputSystemUIInputModuleVariable, InputSystemUIInputModuleRef>
	{
		public InputSystemUIInputModuleOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleListOverride : VariableOverride<List<UnityEngine.InputSystem.UI.InputSystemUIInputModule>, InputSystemUIInputModuleListVariable, InputSystemUIInputModuleListVar>
	{
		public InputSystemUIInputModuleListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.UI.InputSystemUIInputModule))]
	public sealed partial class InputSystemUIInputModuleListOutput : VariableOutput<List<UnityEngine.InputSystem.UI.InputSystemUIInputModule>, InputSystemUIInputModuleListVariable, InputSystemUIInputModuleListRef>
	{
		public InputSystemUIInputModuleListOutput(IVariable variable) : base(variable)
		{
		}
	}
}

#endif
