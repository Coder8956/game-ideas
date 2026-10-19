
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeVariable : Variable<UnityEngine.IMECompositionMode>
	{
		
		public IMECompositionModeVariable()
		{
		}
		
		public IMECompositionModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeListVariable : ListVariable<UnityEngine.IMECompositionMode>
	{
		
		public IMECompositionModeListVariable()
		{
		}
		
		public IMECompositionModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeRef : VariableRef<UnityEngine.IMECompositionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeVar : VariableVar<UnityEngine.IMECompositionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeListRef : ListVariableRef<UnityEngine.IMECompositionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.IMECompositionMode))]
	public sealed partial class IMECompositionModeListVar : ListVariableVar<UnityEngine.IMECompositionMode>
	{
	}
}
