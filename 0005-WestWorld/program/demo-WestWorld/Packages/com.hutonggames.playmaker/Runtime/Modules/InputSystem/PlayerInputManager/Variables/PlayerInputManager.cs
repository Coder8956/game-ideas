#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerVariable : Variable<UnityEngine.InputSystem.PlayerInputManager>
	{
		
		public PlayerInputManagerVariable()
		{
		}
		
		public PlayerInputManagerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerListVariable : ListVariable<UnityEngine.InputSystem.PlayerInputManager>
	{
		
		public PlayerInputManagerListVariable()
		{
		}
		
		public PlayerInputManagerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerRef : BaseComponentRef<UnityEngine.InputSystem.PlayerInputManager>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerVar : BaseComponentVar<UnityEngine.InputSystem.PlayerInputManager>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerListRef : ListVariableRef<UnityEngine.InputSystem.PlayerInputManager>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerListVar : ListVariableVar<UnityEngine.InputSystem.PlayerInputManager>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerOverride : VariableOverride<UnityEngine.InputSystem.PlayerInputManager, PlayerInputManagerVariable, PlayerInputManagerVar>
	{
		public PlayerInputManagerOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerOutput : VariableOutput<UnityEngine.InputSystem.PlayerInputManager, PlayerInputManagerVariable, PlayerInputManagerRef>
	{
		public PlayerInputManagerOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerListOverride : VariableOverride<List<UnityEngine.InputSystem.PlayerInputManager>, PlayerInputManagerListVariable, PlayerInputManagerListVar>
	{
		public PlayerInputManagerListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.PlayerInputManager))]
	public sealed partial class PlayerInputManagerListOutput : VariableOutput<List<UnityEngine.InputSystem.PlayerInputManager>, PlayerInputManagerListVariable, PlayerInputManagerListRef>
	{
		public PlayerInputManagerListOutput(IVariable variable) : base(variable)
		{
		}
	}
}

#endif
