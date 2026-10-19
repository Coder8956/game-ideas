
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeVariable : Variable<UnityEngine.PlayMode>
	{
		
		public PlayModeVariable()
		{
		}
		
		public PlayModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeListVariable : ListVariable<UnityEngine.PlayMode>
	{
		
		public PlayModeListVariable()
		{
		}
		
		public PlayModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeRef : VariableRef<UnityEngine.PlayMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeVar : VariableVar<UnityEngine.PlayMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeListRef : ListVariableRef<UnityEngine.PlayMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlayMode))]
	public sealed partial class PlayModeListVar : ListVariableVar<UnityEngine.PlayMode>
	{
	}
}
