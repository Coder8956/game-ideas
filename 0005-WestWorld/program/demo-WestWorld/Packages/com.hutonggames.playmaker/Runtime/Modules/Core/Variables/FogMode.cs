
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeVariable : Variable<UnityEngine.FogMode>
	{
		
		public FogModeVariable()
		{
		}
		
		public FogModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeListVariable : ListVariable<UnityEngine.FogMode>
	{
		
		public FogModeListVariable()
		{
		}
		
		public FogModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeRef : VariableRef<UnityEngine.FogMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeVar : VariableVar<UnityEngine.FogMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeListRef : ListVariableRef<UnityEngine.FogMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FogMode))]
	public sealed partial class FogModeListVar : ListVariableVar<UnityEngine.FogMode>
	{
	}
}
