
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeVariable : Variable<UnityEngine.FullScreenMode>
	{
		
		public FullScreenModeVariable()
		{
		}
		
		public FullScreenModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeListVariable : ListVariable<UnityEngine.FullScreenMode>
	{
		
		public FullScreenModeListVariable()
		{
		}
		
		public FullScreenModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeRef : VariableRef<UnityEngine.FullScreenMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeVar : VariableVar<UnityEngine.FullScreenMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeListRef : ListVariableRef<UnityEngine.FullScreenMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FullScreenMode))]
	public sealed partial class FullScreenModeListVar : ListVariableVar<UnityEngine.FullScreenMode>
	{
	}
}
