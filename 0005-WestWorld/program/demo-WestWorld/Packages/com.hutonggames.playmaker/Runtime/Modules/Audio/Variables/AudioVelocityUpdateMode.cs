
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeVariable : Variable<UnityEngine.AudioVelocityUpdateMode>
	{
		
		public AudioVelocityUpdateModeVariable()
		{
		}
		
		public AudioVelocityUpdateModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeListVariable : ListVariable<UnityEngine.AudioVelocityUpdateMode>
	{
		
		public AudioVelocityUpdateModeListVariable()
		{
		}
		
		public AudioVelocityUpdateModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeRef : VariableRef<UnityEngine.AudioVelocityUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeVar : VariableVar<UnityEngine.AudioVelocityUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeListRef : ListVariableRef<UnityEngine.AudioVelocityUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioVelocityUpdateMode))]
	public sealed partial class AudioVelocityUpdateModeListVar : ListVariableVar<UnityEngine.AudioVelocityUpdateMode>
	{
	}
}
