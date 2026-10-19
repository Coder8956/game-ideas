#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetVariable : Variable<UnityEngine.InputSystem.InputActionAsset>
	{
		
		public InputActionAssetVariable()
		{
		}
		
		public InputActionAssetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetListVariable : ListVariable<UnityEngine.InputSystem.InputActionAsset>
	{
		
		public InputActionAssetListVariable()
		{
		}
		
		public InputActionAssetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetRef : VariableRef<UnityEngine.InputSystem.InputActionAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetVar : VariableVar<UnityEngine.InputSystem.InputActionAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetListRef : ListVariableRef<UnityEngine.InputSystem.InputActionAsset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetListVar : ListVariableVar<UnityEngine.InputSystem.InputActionAsset>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetOverride : VariableOverride<UnityEngine.InputSystem.InputActionAsset, InputActionAssetVariable, InputActionAssetVar>
	{
		public InputActionAssetOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetOutput : VariableOutput<UnityEngine.InputSystem.InputActionAsset, InputActionAssetVariable, InputActionAssetRef>
	{
		public InputActionAssetOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetListOverride : VariableOverride<List<UnityEngine.InputSystem.InputActionAsset>, InputActionAssetListVariable, InputActionAssetListVar>
	{
		public InputActionAssetListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.InputSystem.InputActionAsset))]
	public sealed partial class InputActionAssetListOutput : VariableOutput<List<UnityEngine.InputSystem.InputActionAsset>, InputActionAssetListVariable, InputActionAssetListRef>
	{
		public InputActionAssetListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
#endif
