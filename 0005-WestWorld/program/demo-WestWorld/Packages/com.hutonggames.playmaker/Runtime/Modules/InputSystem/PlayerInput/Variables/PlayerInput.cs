#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputVariable : Variable<UnityEngine.InputSystem.PlayerInput>
	{
		
		public PlayerInputVariable()
		{
		}
		
		public PlayerInputVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputListVariable : ListVariable<UnityEngine.InputSystem.PlayerInput>
	{
		
		public PlayerInputListVariable()
		{
		}
		
		public PlayerInputListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputRef : BaseComponentRef<UnityEngine.InputSystem.PlayerInput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputVar : BaseComponentVar<UnityEngine.InputSystem.PlayerInput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputListRef : ListVariableRef<UnityEngine.InputSystem.PlayerInput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputListVar : ListVariableVar<UnityEngine.InputSystem.PlayerInput>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputOverride : VariableOverride<UnityEngine.InputSystem.PlayerInput, PlayerInputVariable, PlayerInputVar>
	{
		public PlayerInputOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputOutput : VariableOutput<UnityEngine.InputSystem.PlayerInput, PlayerInputVariable, PlayerInputRef>
	{
		public PlayerInputOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputListOverride : VariableOverride<List<UnityEngine.InputSystem.PlayerInput>, PlayerInputListVariable, PlayerInputListVar>
	{
		public PlayerInputListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInput))]
	public sealed partial class PlayerInputListOutput : VariableOutput<List<UnityEngine.InputSystem.PlayerInput>, PlayerInputListVariable, PlayerInputListRef>
	{
		public PlayerInputListOutput(IVariable variable) : base(variable)
		{
		}
	}
}

#endif
