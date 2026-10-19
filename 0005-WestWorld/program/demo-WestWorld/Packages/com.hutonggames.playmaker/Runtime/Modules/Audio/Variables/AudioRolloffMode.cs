
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeVariable : Variable<UnityEngine.AudioRolloffMode>
	{
		
		public AudioRolloffModeVariable()
		{
		}
		
		public AudioRolloffModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeListVariable : ListVariable<UnityEngine.AudioRolloffMode>
	{
		
		public AudioRolloffModeListVariable()
		{
		}
		
		public AudioRolloffModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeRef : VariableRef<UnityEngine.AudioRolloffMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeVar : VariableVar<UnityEngine.AudioRolloffMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeListRef : ListVariableRef<UnityEngine.AudioRolloffMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioRolloffMode))]
	public sealed partial class AudioRolloffModeListVar : ListVariableVar<UnityEngine.AudioRolloffMode>
	{
	}
}
